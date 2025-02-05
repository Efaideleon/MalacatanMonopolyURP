using UnityEngine.UIElements;

public class RollDisplay
{
    private readonly VisualElement _root;
    private const string RollDisplayContainerClassName = "roll-display-container";
    private const string RollButtonClassName = "roll-button";
    private VisualElement _rollDisplayContainer;
    private Button _rollButton;

    public RollDisplay(VisualElement root)
    {
        _root = root;
        Initialize();
    }

    private void Initialize()
    {
        _rollDisplayContainer = _root.Q<VisualElement>(RollDisplayContainerClassName);
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
        _rollDisplayContainer.style.display = DisplayStyle.Flex;
    } 

    // Right now it hides the entire display container 
    private void HideRollButton() 
    {
        // _rollButton.style.display = DisplayStyle.None;
        _rollDisplayContainer.style.display = DisplayStyle.None;
    }

    private void OnRollClicked()
    {
        GameplayEvents.OnRoll?.Invoke();
        HideRollButton();
    }
}
