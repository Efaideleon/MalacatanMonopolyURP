using UnityEngine;
using UnityEngine.UIElements;

// Controls what UI Element should be visible.
[CreateAssetMenu(fileName = "UIManagerData", menuName = "Scriptable Objects/UI/UIManagerData")]
public class UIManagerData : ScriptableObject
{
    [SerializeField] private DisplayStyle _gameScreenUIDisplay = DisplayStyle.None;  
    public StyleEnum<DisplayStyle> GameScreenUIDisplay => _gameScreenUIDisplay;

    public void ShowGameScreenUI(bool state)
    {
        _gameScreenUIDisplay = state ? DisplayStyle.Flex : DisplayStyle.None;
    }
}
