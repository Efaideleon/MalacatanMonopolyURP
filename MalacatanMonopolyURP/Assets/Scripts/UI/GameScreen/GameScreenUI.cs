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

    private Label _taxLabel;
    private Label _jailLabel;
    private Label _goToJailLabel;
    private Label _chanceLabel;
    private Label _goLabel;
    private Label _parkingLabel;
    private Label _treasureLabel;

    private Button _taxButton;
    private Button _jailButton;
    private Button _goToJailButton;
    private Button _chanceButton;
    private Button _goButton;
    private Button _parkingButton;
    private Button _treasureButton;

    private VisualElement _taxContainer;
    private VisualElement _jailContainer;
    private VisualElement _goToJailContainer;
    private VisualElement _chanceContainer;
    private VisualElement _goContainer;
    private VisualElement _parkingContainer;
    private VisualElement _treasureContainer;

    public GameScreenUI(VisualElement root)
    {
        _root = root;
        Initialize();
    }

    private void Initialize()
    {
        _taxLabel = _root.Q<Label>(TaxLabelClassName);
        _jailLabel = _root.Q<Label>(JailLabelClassName);
        _goToJailLabel = _root.Q<Label>(GoToJailLabelClassName);
        _chanceLabel = _root.Q<Label>(ChanceLabelClassName);
        _goLabel = _root.Q<Label>(GoLabelClassName);
        _parkingLabel = _root.Q<Label>(ParkingLabelClassName);
        _treasureLabel = _root.Q<Label>(TreasureLabelClassName);

        _taxButton = _root.Q<Button>(TaxButtonClassName);
        _jailButton = _root.Q<Button>(JailButtonClassName);
        _goToJailButton = _root.Q<Button>(GoToJailButtonClassName);
        _chanceButton = _root.Q<Button>(ChanceButtonClassName);
        _goButton = _root.Q<Button>(GoButtonClassName);
        _parkingButton = _root.Q<Button>(ParkingButtonClassName);
        _treasureButton = _root.Q<Button>(TreasureButtonClassName);

        _taxContainer = _root.Q<VisualElement>(TaxDisplayContainerClassName);
        _jailContainer = _root.Q<VisualElement>(JailDisplayContainerClassName);
        _goToJailContainer = _root.Q<VisualElement>(GoToJailContainerClassName);
        _chanceContainer = _root.Q<VisualElement>(ChanceDisplayContainerClassName);
        _goContainer = _root.Q<VisualElement>(GoDisplayContainerClassName);
        _parkingContainer = _root.Q<VisualElement>(ParkingDisplayContainerClassName);
        _treasureContainer = _root.Q<VisualElement>(TreasureDisplayContainerClassName);
    }
}
