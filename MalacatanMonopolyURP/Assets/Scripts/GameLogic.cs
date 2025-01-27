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

    public event Action<int> OnPlayerTurnChange;
    public event Action OnPlayersQueueFilled;

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
            // TODO: Position should loop around the map.
            var currentPlayer = _playersQueue.Dequeue();
            Debug.Log($"Player: {currentPlayer.PlayerNumber} Rolled: {_rolledDiceValue}");
            var newPlayerBoardIndex = (currentPlayer.PositionOnBoardIndex + _rolledDiceValue) % 40;
            var newPlayerPos = _gameBoard.GetTilePositionAt(newPlayerBoardIndex);
            currentPlayer.MovePositionTo(newPlayerBoardIndex, newPlayerPos);

            // Move to the next player.
            _playersQueue.Enqueue(currentPlayer);
            OnPlayerTurnChange?.Invoke(CurrentActivePlayer.PlayerNumber);
        }
    }
    
    void OnDestroy()
    {
        _gameData.Reset();
    }
}
