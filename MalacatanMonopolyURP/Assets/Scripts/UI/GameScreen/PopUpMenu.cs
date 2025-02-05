using UnityEngine.UIElements;

public class PopUpMenu
{
    private const string PopUpMenuClassName = "popup-menu-container";
    private const string AcceptButtonClassName = "popup-menu-accept-button";
    private const string DeclineButtonClassName = "popup-menu-decline-button";
    private VisualElement _root;
    private VisualElement _popUpMenuContainer;
    private Button _popUpMenuDeclineButton;
    private Button _popUpMenuAcceptButton;

    public PopUpMenu(VisualElement root)
    {
        _root = root;
        Initialize();
    }

    private void Initialize()
    {
        // Getting references to uxml attributes in PopUp Menu
        _popUpMenuContainer = _root.Q<VisualElement>(PopUpMenuClassName);
        _popUpMenuAcceptButton = _root.Q<Button>(AcceptButtonClassName);
        _popUpMenuDeclineButton = _root.Q<Button>(DeclineButtonClassName);

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
    }

    // TODO: Maybe pass the text for the label here.
    private void ShowPopUpMenu() 
    {
        _popUpMenuContainer.style.display = DisplayStyle.Flex;
    }

    private void HidePopUpMenu() => _popUpMenuContainer.style.display = DisplayStyle.None;
}
