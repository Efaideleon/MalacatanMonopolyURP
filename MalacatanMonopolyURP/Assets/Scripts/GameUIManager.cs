using System.Linq;
using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private GameLogic _gameLogic;
    [SerializeField] private GameMenu _gameMenu;
    [SerializeField] private PlayerUI _playerUI;
    [SerializeField] private PlayerUIData _playerUIData;

    void OnEnable()
    {
        _gameLogic.OnPlayersQueueFilled += HandleGameStart;
        _gameLogic.OnPlayerTurnEnded += ShowRollButton;
        _gameLogic.OnLandedOnPropertySpace += ShowBuyMenu;
        _gameLogic.OnDiceRolled += HideRollDiceButton;
        _gameLogic.OnBuyProperty += ShowYouBoughtPanel;
    }

    void OnDisable()
    {
        _gameLogic.OnPlayersQueueFilled -= HandleGameStart;
        _gameLogic.OnPlayerTurnEnded -= ShowRollButton;
        _gameLogic.OnLandedOnPropertySpace -= ShowBuyMenu;
        _gameLogic.OnDiceRolled -= HideRollDiceButton;
        _gameLogic.OnBuyProperty -= ShowYouBoughtPanel;
    }

    private void HideRollDiceButton()
    {
        _playerUI.HideRollDiceButton();
    }

    private void ShowBuyMenu(PropertySpace property)
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
            _playerUIData.ChangePlayerName($"{_gameLogic.CurrentActivePlayer.Name}");
            _playerUIData.UpdateMoney(_gameLogic.CurrentActivePlayer.Money);
        }
        else
        {
            Debug.LogWarning("No players in the queue.");
        }
    }

    private void ShowYouBoughtPanel()
    {
        // TODO: HOw are we going to get the name from the property????
        _playerUI.ShowYouBoughtPanel();
    }
}

