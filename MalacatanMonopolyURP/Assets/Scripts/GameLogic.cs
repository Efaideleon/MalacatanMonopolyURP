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

    private Queue<Character> _playersQueue = new Queue<Character>();
    private int _rolledDiceValue = 0;

    public Character CurrentActivePlayer => _playersQueue.Peek();

    public event Action<int> OnPlayerTurnChange;

    void OnEnable()
    {
        _gameData.OnAllCharacterPicked += FillPlayersQueue;
    }

    void Start()
    {
        _gameData.Reset();
    }

    private void FillPlayersQueue()
    {
        foreach (var character in _gameData.ListOfCharactersPicked)
        {
            _playersQueue.Enqueue(character);
        }
    }

    public void RollDice()
    {
        _rolledDiceValue = UnityEngine.Random.Range(1, 7);
        if (CurrentActivePlayer)
        {
            _playersQueue.Enqueue(_playersQueue.Dequeue());
            OnPlayerTurnChange?.Invoke(CurrentActivePlayer.PlayerNumber);
        }
        Debug.Log($"Value Rolled: {_rolledDiceValue}");
    }
    
    void OnDestroy()
    {
        _gameData.Reset();
    }
}
