using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Button _rollDiceButton;
    [SerializeField] private GameData _gameData;
    [SerializeField] private GameBoard _gameBoard;
    [SerializeField] private CharacterSpawner _characterSpawner;

    private Queue<Character> _playersQueue = new Queue<Character>();
    private int _rolledDiceValue = 0;

    public Character CurrentActivePlayer => _playersQueue.Peek();

    public event Action OnPlayerTurnEnded;
    public event Action OnPlayersQueueFilled;
    public event Action OnDiceRolled;

    void OnEnable()
    {
        _characterSpawner.OnAllCharactersSpawned += FillPlayersQueue;
    }

    void OnDisable()
    {
        _characterSpawner.OnAllCharactersSpawned -= FillPlayersQueue;
    }

    void Start()
    {
        _gameData.Reset();
    }

    private void FillPlayersQueue()
    {
        foreach (var character in _gameData.ListOfInstancesOfCharactersPicked)
        {
            _playersQueue.Enqueue(character);
        }
        foreach (var player in _playersQueue)
        {
            Debug.Log($"Player: {player.Name}");
        }
        OnPlayersQueueFilled?.Invoke();
    }

    public void RollDice()
    {
        _rolledDiceValue = UnityEngine.Random.Range(1, 7);
        if (CurrentActivePlayer)
        {
            // Moving the player posiiton on the board.
            Debug.Log($"Player: {CurrentActivePlayer.PlayerNumber} Rolled: {_rolledDiceValue}");
            var newPlayerBoardIndex = (CurrentActivePlayer.PositionOnBoardIndex + _rolledDiceValue) % 40;
            var newPlayerPos = _gameBoard.GetMarkerPositionAt(newPlayerBoardIndex);
            CurrentActivePlayer.MovePositionTo(newPlayerBoardIndex, newPlayerPos);

            // Player has rolled the dice, but their turn is not over yet.
            OnDiceRolled?.Invoke();
        }
    }

    public void ChangeToNextPlayer()
    {
        var currentPlayer = _playersQueue.Dequeue();
        _playersQueue.Enqueue(currentPlayer);

        // Player turn is over after choosing to buy or not.
        OnPlayerTurnEnded?.Invoke();
    }
    
    void OnDestroy()
    {
        _gameData.Reset();
    }
}
