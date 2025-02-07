using UnityEngine.UIElements;

public class AlertPopUp
{
    private string _containerClassName;
    private string _buttonClassName;
    private string _labelClassName;
    private Button _okButton;
    private Label _label;
    private VisualElement _container;
    private VisualElement _root;

    private GameLogic _gameLogic;

    public AlertPopUp(VisualElement root, string containerClassName, string buttonClassName, string labelClassName, GameLogic gameLogic)
    {
        _root = root;
        _buttonClassName = buttonClassName;
        _labelClassName = labelClassName;
        _containerClassName = containerClassName;
        _gameLogic = gameLogic;
        Initialize();
    }

    private void Initialize()
    {
        _container = _root.Q<VisualElement>(_containerClassName);
        _okButton = _container.Q<Button>(_buttonClassName);
        _label = _container.Q<Label>(_labelClassName);

        Hide();
        SubscribeEvents();
    }

    public void Dispose()
    {
        UnsubcribeEvents();
    }

    private void SubscribeEvents()
    {
        _okButton.clicked += OnOkButtonClicked;
    }

    private void UnsubcribeEvents()
    {
        _okButton.clicked -= OnOkButtonClicked;
    }

    public void Show(string label) 
    {
        _label.text = label;
        _container.style.display = DisplayStyle.Flex;
    } 

    private void OnOkButtonClicked()
    {
        _gameLogic.ChangeToNextPlayer();
        Hide();
    }

    private void Hide() 
    {
        _container.style.display = DisplayStyle.None;
    }
}

