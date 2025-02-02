using UnityEngine.UIElements;

public class RollDisplay
{
    private const string RollButtonClassName = "roll-button";
    private readonly VisualElement _root;
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
        GameplayEvents.OnPlayerTurnEnded -= ShowRollButton;
    }

    private void ShowRollButton() => _rollButton.style.display = DisplayStyle.Flex;
    private void HideRollButton() => _rollButton.style.display = DisplayStyle.None;

    private void OnRollClicked()
    {
        GameplayEvents.OnRoll?.Invoke();
        HideRollButton();
    }
}