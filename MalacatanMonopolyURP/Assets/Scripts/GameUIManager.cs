using System.Linq;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private GameLogic _gameLogic;
    [SerializeField] private GameMenu _gameMenu;
    [SerializeField] private PlayerUI _playerUI;

    void OnEnable()
    {
        _gameLogic.OnPlayersQueueFilled += HandleGameStart;
        _gameLogic.OnPlayerTurnEnded += UpdateUICurrentPlayerName;
        _gameLogic.OnPlayerTurnEnded += ShowRollButton;
        _gameLogic.OnPlayerTurnEnded += UpdateMoneyText;
        _gameLogic.OnDiceRolled += ShowBuyMenu;
        _gameLogic.OnDiceRolled += HideRollDiceButton;
        _gameLogic.OnDiceRolled += UpdateRolledAmountText;
        _gameLogic.OnBuyProperty += UpdateMoneyText;
        _gameLogic.OnBuyProperty += ShowYouBoughtPanel;
    }

    void OnDisable()
    {
        _gameLogic.OnPlayersQueueFilled -= HandleGameStart;
        _gameLogic.OnPlayerTurnEnded -= UpdateUICurrentPlayerName;
        _gameLogic.OnPlayerTurnEnded -= ShowRollButton;
        _gameLogic.OnPlayerTurnEnded -= UpdateMoneyText;
        _gameLogic.OnDiceRolled -= ShowBuyMenu;
        _gameLogic.OnDiceRolled -= HideRollDiceButton;
        _gameLogic.OnDiceRolled -= UpdateRolledAmountText;
        _gameLogic.OnBuyProperty -= UpdateMoneyText;
        _gameLogic.OnBuyProperty -= ShowYouBoughtPanel;
    }

    private void HideRollDiceButton()
    {
        _playerUI.HideRollDiceButton();
    }

    private void ShowBuyMenu()
    {
        _playerUI.ShowBuyMenu();
    }

    private void ShowRollButton()
    {
        _playerUI.ShowRollDiceButton();
    }

    // When the players instances have been created, Start the game.
    private void HandleGameStart()
    {
        // When the players have been instantiated, hide the Start Menu
        // and show the player UI.
        _gameMenu.gameObject.SetActive(false);
        _playerUI.gameObject.SetActive(true);

        if (_gameLogic.CurrentActivePlayer)
        {
            Debug.Log($"Starting: Current Active player: {_gameLogic.CurrentActivePlayer.Name}");
            Debug.Log($"Starting: Current Active player Number: {_gameLogic.CurrentActivePlayer.PlayerNumber}");
            _playerUI.UpdatePlayerName(_gameLogic.CurrentActivePlayer.PlayerNumber);
            UpdateMoneyText();
        }
        else
        {
            Debug.LogWarning("No players in the queue.");
        }
    }

    // When the player rolls the dice, the player turn changes.
    private void UpdateUICurrentPlayerName()
    {
        if (_gameLogic.CurrentActivePlayer)
        {
            Debug.Log($"Current Active player: {_gameLogic.CurrentActivePlayer}");
            _playerUI.UpdatePlayerName(_gameLogic.CurrentActivePlayer.PlayerNumber);
        }
        else 
        {
            Debug.LogWarning("No players in the queue.");
        }
    }

    private void UpdateRolledAmountText()
    {
        _playerUI.UpdateRolledAmountText(_gameLogic.RolledAmount);
    }

    private void UpdateMoneyText()
    {
        _playerUI.UpdateMoneyText(_gameLogic.CurrentActivePlayer.Money);
    }

    private void ShowYouBoughtPanel()
    {
        _playerUI.ShowYouBoughtPanel(_gameLogic.CurrentActivePlayer.PropertiesOwned.Last().PlaceName);
    }
}

