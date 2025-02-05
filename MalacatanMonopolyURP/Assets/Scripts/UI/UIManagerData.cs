using UnityEngine;
using UnityEngine.UIElements;

// Controls what UI Element should be visible.
[CreateAssetMenu(fileName = "UIManagerData", menuName = "Scriptable Objects/UI/UIManagerData")]
public class UIManagerData : ScriptableObject
{
    // Make visible (Display.Flex) for creating on uxml on Scriptable Object instance.
    [SerializeField] private DisplayStyle _gameScreenUIDisplay = DisplayStyle.None;  
    public StyleEnum<DisplayStyle> GameScreenUIDisplay => _gameScreenUIDisplay;

    public void ShowGameScreenUI(bool state)
    {
        _gameScreenUIDisplay = state ? DisplayStyle.Flex : DisplayStyle.None;
    }
}
