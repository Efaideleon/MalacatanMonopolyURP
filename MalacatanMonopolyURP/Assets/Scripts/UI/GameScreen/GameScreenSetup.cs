using UnityEngine;
using UnityEngine.UIElements;

public class GameScreenSetup : MonoBehaviour
{
    [SerializeField] private UIDocument _uIDocument;
    private RollDisplay _rollDisplay;
    private PopUpMenu _popUpMenu;    
    private VisualElement _root;

    void Start()
    {
        /*_root = _uIDocument.rootVisualElement.Q<VisualElement>("game-screen");*/
        /**/
        /*_rollDisplay = new RollDisplay(_root);*/
        /*_popUpMenu = new PopUpMenu(_root);*/
    }

    void OnDestroy()
    {
        // _rollDisplay.Dispose();
    }
}
