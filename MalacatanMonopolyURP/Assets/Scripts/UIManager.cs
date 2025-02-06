using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameLogic _gameLogic;
    [SerializeField] private GameScreenUIData _gameScreenUIData;
    [SerializeField] private UIManagerData _uIManagerData;

    void Start()
    {
        _uIManagerData.ShowGameScreenUI(false);
    }
    void OnEnable()
    {
        _gameLogic.OnPlayersQueueFilled += HandleGameStart;
        _gameLogic.OnLandedOnPropertySpace += ShowBuyMenu;
    }

    void OnDisable()
    {
        _gameLogic.OnPlayersQueueFilled -= HandleGameStart;
        _gameLogic.OnLandedOnPropertySpace -= ShowBuyMenu;
    }

    private void ShowBuyMenu(PropertySpace property)
    {
        _gameScreenUIData.UpdateNameOfPropertyToBuy(property.Data.Name);
        _gameScreenUIData.UpdatePriceOfPropertyToBuy(property.Data.price);
    }

    // When the players instances have been created, Start the game.
    private void HandleGameStart()
    {
        _uIManagerData.ShowGameScreenUI(true);
    }
}
