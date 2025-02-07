using UnityEngine;
using UnityEngine.UIElements;

public class GameScreenSetup : MonoBehaviour
{
    [SerializeField] private UIDocument _uIDocument;
    [SerializeField] private GameLogic _gameLogic;
    private RollDisplay _rollDisplay;
    private PopUpMenu _popUpMenu;    
    private YouBoughtDisplay _youBoughtDisplay;    
    private VisualElement _root;

    private GameScreenUI _gameScreenUI;
    private VisualElement _gameScreenAlertRoot;

    void Start()
    {
        VisualElement popUpRoot = _uIDocument.rootVisualElement.Q<VisualElement>("popup-menu-container");
        VisualElement rollRoot = _uIDocument.rootVisualElement.Q<VisualElement>("roll-display-container");
        VisualElement youBoughtDisplayRoot = _uIDocument.rootVisualElement.Q<VisualElement>("you-bought-display-container");
        _rollDisplay = new RollDisplay(rollRoot);
        _popUpMenu = new PopUpMenu(popUpRoot, _gameLogic);
        _youBoughtDisplay = new YouBoughtDisplay(youBoughtDisplayRoot, _gameLogic);

        VisualElement _gameScreenAlertRoot = _uIDocument.rootVisualElement.Q<VisualElement>("game-screen-bottom-container");
        _gameScreenUI = new GameScreenUI(_gameScreenAlertRoot, _gameLogic);
    }

    void OnDestroy()
    {
        // _rollDisplay.Dispose();
    }
}
