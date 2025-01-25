using System;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Button _rollDiceButton;

    private int _currentActivePlayer = 1;
    private int _rolledDiceValue = 0;

    public event Action<int> OnPlayerTurnChange;

    void Start()
    {
        OnPlayerTurnChange?.Invoke(_currentActivePlayer);
    }

    public void RollDice()
    {
        _rolledDiceValue = UnityEngine.Random.Range(1, 7);
        Debug.Log($"Value Rolled: {_rolledDiceValue}");
    }
}
