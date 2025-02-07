using UnityEngine.UIElements;

// Controls all the pop up windows excpet for buy menu, and you bought popup
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
        SubscribesPopToOnLandEvents();
    }

    private void Initialize()
    {
        _taxPopUp = new AlertPopUp(_root, TaxDisplayContainerClassName, TaxButtonClassName, TaxLabelClassName, _gameLogic);
        _jailPopUp = new AlertPopUp(_root, JailDisplayContainerClassName, JailButtonClassName, JailLabelClassName, _gameLogic);
        _goToJailPopUp = new AlertPopUp(_root, GoToJailContainerClassName, GoToJailButtonClassName, GoToJailLabelClassName, _gameLogic);
        _chancePopUp = new AlertPopUp(_root, ChanceDisplayContainerClassName, ChanceButtonClassName, ChanceLabelClassName, _gameLogic);
        _goPopUp = new AlertPopUp(_root, GoDisplayContainerClassName, GoButtonClassName, GoLabelClassName, _gameLogic);
        _parkingPopUp = new AlertPopUp(_root, ParkingDisplayContainerClassName, ParkingButtonClassName, ParkingLabelClassName, _gameLogic);
        _treasurePopUp = new AlertPopUp(_root, TreasureDisplayContainerClassName, TreasureButtonClassName, TreasureLabelClassName, _gameLogic);
    }

    private void SubscribesPopToOnLandEvents()
    {
        GameplayEvents.OnLandedOnTaxSpace += ShowTaxPopUp;
        GameplayEvents.OnLandedOnJailSpace += ShowJailPopUp;
        GameplayEvents.OnLandedOnGoToJailSpace += ShowGoToJailPopUp;
        GameplayEvents.OnLandedOnChanceSpace += ShowChancePopUp;
        GameplayEvents.OnLandedOnGoSpace += ShowGoPopUp;
        GameplayEvents.OnLandedOnParkingSpace += ShowParkingPopUp;
        GameplayEvents.OnLandedOnTreasureSpace += ShowTreasurePopUp;
    }

    private void UnSubscribeFromOnLandEvents()
    {
        GameplayEvents.OnLandedOnTaxSpace -= ShowTaxPopUp;
        GameplayEvents.OnLandedOnJailSpace -= ShowJailPopUp;
        GameplayEvents.OnLandedOnGoToJailSpace -= ShowGoToJailPopUp;
        GameplayEvents.OnLandedOnChanceSpace -= ShowChancePopUp;
        GameplayEvents.OnLandedOnGoSpace -= ShowGoPopUp;
        GameplayEvents.OnLandedOnParkingSpace -= ShowParkingPopUp;
        GameplayEvents.OnLandedOnTreasureSpace -= ShowTreasurePopUp;
    }

    private void ShowTaxPopUp(TaxSpace space)
    {
        string label = $"You were taxed {space.Data.TaxAmount}";
        _taxPopUp.Show(label);
    }

    private void ShowJailPopUp(JailSpace space)
    {
        string label = $"You are in jail for 1 turn!";
        _jailPopUp.Show(label);
    }

    private void ShowGoToJailPopUp(GoToJailSpace space)
    {
        string label = "Go to Jail";
        _goToJailPopUp.Show(label);
    }

    private void ShowChancePopUp(ChanceSpace space)
    {
        string label = "idk";
        _chancePopUp.Show(label);
    }

    private void ShowGoPopUp(GoSpace space)
    {
        string label = "You got 200!";
        _goPopUp.Show(label);
    }

    private void ShowParkingPopUp(ParkingSpace space)
    {
        string label = "Parking stuff";
        _parkingPopUp.Show(label);
    }

    private void ShowTreasurePopUp(TreasureSpace space)
    {
        string label = "Treasure stuff idk";
        _treasurePopUp.Show(label);
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
        UnSubscribeFromOnLandEvents();
    }
}
