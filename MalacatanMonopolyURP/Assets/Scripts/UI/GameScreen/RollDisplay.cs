using UnityEngine.UIElements;

public class RollDisplay
{
    private readonly VisualElement _root;
    private const string RollButtonClassName = "roll-button";
    private Button _rollButton;

    public RollDisplay(VisualElement root)
    {
        _root = root;
        Initialize();
    }

    private void Initialize()
    {
        _rollButton = _root.Q<Button>(RollButtonClassName);
        _rollButton.clicked += OnRollClicked;
        SubscribeEvents();
    }

    public void Dispose()
    {
        UnsubcribeEvents();
    }

    // Subscribe to event that would make the roll button appear again.
    private void SubscribeEvents()
    {
        GameplayEvents.OnPlayerTurnEnded += ShowRollButton;
    }

    private void UnsubcribeEvents()
    {
        _rollButton.clicked -= OnRollClicked;
        GameplayEvents.OnPlayerTurnEnded -= ShowRollButton;
    }

    private void ShowRollButton() 
    {
        // _rollButton.style.display = DisplayStyle.Flex;
        _root.style.display = DisplayStyle.Flex;
    } 

    // Right now it hides the entire display container 
    private void HideRollButton() 
    {
        // _rollButton.style.display = DisplayStyle.None;
        _root.style.display = DisplayStyle.None;
    }

    private void OnRollClicked()
    {
        GameplayEvents.OnRoll?.Invoke();
        HideRollButton();
    }
}
