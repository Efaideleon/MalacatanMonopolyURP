using UnityEngine;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private GameLogic _gameLogic;
    [SerializeField] private GameMenu _gameMenu;
    [SerializeField] private PlayerUI _playerUI;

    void OnEnable()
    {
        _gameLogic.OnPlayersQueueFilled += HandleGameStart;
        _gameLogic.OnPlayerTurnChange += HandlePlayerTurnChange;
    }

    void OnDisable()
    {
        _gameLogic.OnPlayersQueueFilled -= HandleGameStart;
        _gameLogic.OnPlayerTurnChange -= HandlePlayerTurnChange;
    }

    private void HandleGameStart()
    {
        _gameMenu.gameObject.SetActive(false);
        _playerUI.gameObject.SetActive(true);
        if (_gameLogic.CurrentActivePlayer)
            Debug.Log($"Starting: Current Active player: {_gameLogic.CurrentActivePlayer.Name}");
            Debug.Log($"Starting: Current Active player Number: {_gameLogic.CurrentActivePlayer.PlayerNumber}");
            _playerUI.UpdatePlayerName(_gameLogic.CurrentActivePlayer.PlayerNumber);
    }

    private void HandlePlayerTurnChange(int currentPlayerNum)
    {
        if (_gameLogic.CurrentActivePlayer)
        {
            Debug.Log($"Current Active player: {_gameLogic.CurrentActivePlayer}");
            _playerUI.UpdatePlayerName(_gameLogic.CurrentActivePlayer.PlayerNumber);
        }
    }
}

