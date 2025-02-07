using UnityEngine.UIElements;

// This pop up menu asks the user if they want to buy the property
public class PopUpMenu
{
    private const string PopUpMenuClassName = "popup-menu-container";
    private const string AcceptButtonClassName = "popup-menu-accept-button";
    private const string DeclineButtonClassName = "popup-menu-decline-button";
    private const string BuyPopUpLabelClassName = "buy-popup-menu-label";
    private VisualElement _root;
    private Button _popUpMenuDeclineButton;
    private Button _popUpMenuAcceptButton;
    private Label _buyPopUpMenuLabel;

    private GameLogic _gameLogic;

    public PopUpMenu(VisualElement root, GameLogic gameLogic)
    {
        _root = root;
        _gameLogic = gameLogic;
        Initialize();
    }

    private void Initialize()
    {
        _popUpMenuAcceptButton = _root.Q<Button>(AcceptButtonClassName);
        _popUpMenuDeclineButton = _root.Q<Button>(DeclineButtonClassName);
        _buyPopUpMenuLabel = _root.Q<Label>(BuyPopUpLabelClassName); 
        HidePopUpMenu();
        SubscribeEvents();
    }

    public void Dispose()
    {
        UnsubcribeEvents();
    }

    // Subscribe to event that would make the roll button appear again.
    private void SubscribeEvents()
    {
        // TODO: If this pop up is dynamic it should respond
        // to different events.
        GameplayEvents.OnLandedOnPropertySpace += ShowPopUpMenu;
        _popUpMenuAcceptButton.clicked += OnAcceptButtonClicked;
        _popUpMenuDeclineButton.clicked += OnDeclineButtonClicked;
    }

    private void UnsubcribeEvents()
    {
        GameplayEvents.OnLandedOnPropertySpace -= ShowPopUpMenu;
        _popUpMenuAcceptButton.clicked -= OnAcceptButtonClicked;
        _popUpMenuDeclineButton.clicked -= OnDeclineButtonClicked;
    }
    
    private void OnAcceptButtonClicked()
    {
        GameplayEvents.OnPropertyPurchased?.Invoke();
        HidePopUpMenu();
    }

    private void OnDeclineButtonClicked()
    {
        HidePopUpMenu();
        ChangeToNextPlayer();
    }

    private void ChangeToNextPlayer()
    {
        _gameLogic.ChangeToNextPlayer();
    }

    // TODO: Maybe pass the text for the label here.
    private void ShowPopUpMenu(PropertySpace property) 
    {
        _root.style.display = DisplayStyle.Flex;
        _buyPopUpMenuLabel.text = property.Data.Name;
    }

    private void HidePopUpMenu() => _root.style.display = DisplayStyle.None;
}
