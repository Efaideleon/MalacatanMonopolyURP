using UnityEngine;
using UnityEngine.UIElements;

public class GameScreenSetup : MonoBehaviour
{
    [SerializeField] private UIDocument _uIDocument;
    private RollDisplay _rollDisplay;
    private VisualElement _root;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _root = _uIDocument.rootVisualElement.Q<VisualElement>("game-screen");
        _rollDisplay = new RollDisplay(_root);
    }

    void OnDestroy()
    {
        _rollDisplay.Dispose();
    }
}
