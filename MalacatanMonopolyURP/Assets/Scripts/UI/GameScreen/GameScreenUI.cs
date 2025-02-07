using UnityEngine.UIElements;

public class GameScreenUI 
{
    private readonly VisualElement _root;
    private const string TaxDisplayContainerClassName = "tax-display-container";
    private const string JailDisplayContainerClassName = "jail-display-container";
    private const string GoToJailContainerClassName = "go-to-jail-display-container";
    private const string ChanceDisplayContainerClassName = "chance-display-container";
    private const string GoDisplayContainerClassName = "go-display-container";
    private const string ParkingDisplayContainerClassName = "parking-display-container";
    private const string TreasureDisplayContainerClassName = "treasure-display-container";

    private const string TaxLabelClassName = "tax-panel-label";
    private const string JailLabelClassName = "jail-panel-label";
    private const string GoToJailLabelClassName = "go-to-jail-panel-label";
    private const string ChanceLabelClassName = "chance-panel-label";
    private const string GoLabelClassName = "go-panel-label";
    private const string ParkingLabelClassName = "parking-panel-label";
    private const string TreasureLabelClassName = "treasure-panel-label";

    private const string TaxButtonClassName = "tax-panel-button";
    private const string JailButtonClassName = "jail-panel-button";
    private const string GoToJailButtonClassName = "go-to-jail-panel-button";
    private const string ChanceButtonClassName = "chance-panel-button";
    private const string GoButtonClassName = "go-panel-button";
    private const string ParkingButtonClassName = "parking-panel-button";
    private const string TreasureButtonClassName = "treasure-panel-button";

    private AlertPopUp _taxPopUp;
    private AlertPopUp _jailPopUp;
    private AlertPopUp _goToJailPopUp;
    private AlertPopUp _chancePopUp;
    private AlertPopUp _goPopUp;
    private AlertPopUp _parkingPopUp;
    private AlertPopUp _treasurePopUp;

    private GameLogic _gameLogic;

    public GameScreenUI(VisualElement root, GameLogic gameLogic)
    {
        _root = root;
        _gameLogic = gameLogic;
        Initialize();
    }

    private void Initialize()
    {
        _taxPopUp = new AlertPopUp(_root, TaxDisplayContainerClassName, TaxButtonClassName, TaxLabelClassName, _gameLogic);
        _jailPopUp = new AlertPopUp(_root, JailDisplayContainerClassName, JailButtonClassName, JailLabelClassName, _gameLogic);
        _goToJailPopUp = new AlertPopUp(_root, GoToJailContainerClassName, GoToJailButtonClassName, GoToJailContainerClassName, _gameLogic);
        _chancePopUp = new AlertPopUp(_root, ChanceDisplayContainerClassName, ChanceButtonClassName, ChanceLabelClassName, _gameLogic);
        _goPopUp = new AlertPopUp(_root, GoDisplayContainerClassName, GoButtonClassName, GoLabelClassName, _gameLogic);
        _parkingPopUp = new AlertPopUp(_root, ParkingDisplayContainerClassName, ParkingButtonClassName, ParkingLabelClassName, _gameLogic);
        _treasurePopUp = new AlertPopUp(_root, TreasureDisplayContainerClassName, TreasureButtonClassName, TreasureLabelClassName, _gameLogic);
    }

    public void Dispose()
    {
        _taxPopUp.Dispose();
        _jailPopUp.Dispose();
        _goToJailPopUp.Dispose();
        _chancePopUp.Dispose();
        _goPopUp.Dispose();
        _parkingPopUp.Dispose();
        _treasurePopUp.Dispose();
    }
}
