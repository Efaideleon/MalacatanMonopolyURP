using UnityEngine.UIElements;
using System.Linq;

public class YouBoughtDisplay
{
    private readonly VisualElement _root;
    private Button _okButton;
    private Label _youBoughtLabel;
    private GameLogic _gameLogic;
    

    public YouBoughtDisplay(VisualElement root, GameLogic gameLogic)
    {
        _root = root;
        _gameLogic = gameLogic;
        Initialize();
    }

    private void Initialize()
    {
        _okButton = _root.Q<Button>("you-bought-ok-button");
        _youBoughtLabel = _root.Q<Label>("you-bought-label");

        HideYouBoughtDisplay();
        SubscribeEvents();
    }

    public void Dispose()
    {
        UnsubcribeEvents();
    }

    private void SubscribeEvents()
    {
        _okButton.clicked += OnOkButtonClicked;
        GameplayEvents.OnPropertyPurchased += ShowYouBoughtDisplay;
    }

    private void UnsubcribeEvents()
    {
        _okButton.clicked -= OnOkButtonClicked;
        GameplayEvents.OnPropertyPurchased -= ShowYouBoughtDisplay;
    }

    private void ShowYouBoughtDisplay() 
    {
        _root.style.display = DisplayStyle.Flex;
        var lastPropertyBought = _gameLogic.CurrentActivePlayer.PropertiesOwned.LastOrDefault();
        if (lastPropertyBought != null)
        {
            _youBoughtLabel.text = $"You Bought: {lastPropertyBought.Data.Name}!";
        }
    } 

    private void HideYouBoughtDisplay() 
    {
        _root.style.display = DisplayStyle.None;
    }

    private void ChangeToNextPlayer()
    {
        _gameLogic.ChangeToNextPlayer();
    }

    private void OnOkButtonClicked()
    {
        HideYouBoughtDisplay();
        ChangeToNextPlayer();
    }
}
