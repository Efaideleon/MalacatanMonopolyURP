using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Button _rollDiceButton;
    [SerializeField] private GameData _gameData;
    [SerializeField] private GameBoard _gameBoard;
    [SerializeField] private CharacterSpawner _characterSpawner;
    [SerializeField] private GameScreenUIData _gameScreenUIData;

    private Queue<Character> _playersQueue = new Queue<Character>();
    private int _rolledDiceValue = 0;
    private int _rolledAmount = 0;

    public Character CurrentActivePlayer => _playersQueue.Peek();
    public int RolledAmount => _rolledAmount; 

    public event Action OnPlayerTurnEnded;
    public event Action OnPlayersQueueFilled;
    public event Action OnDiceRolled;
    public event Action OnBuyProperty;
    public event Action<PropertySpace> OnLandedOnPropertySpace;

    void OnEnable()
    {
        _characterSpawner.OnAllCharactersSpawned += FillPlayersQueue;
        GameplayEvents.OnRoll += RollDice;
    }

    void OnDisable()
    {
        _characterSpawner.OnAllCharactersSpawned -= FillPlayersQueue;
        GameplayEvents.OnRoll -= RollDice;
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
        _gameScreenUIData.PlayerName = CurrentActivePlayer.Name;
        _gameScreenUIData.Money = CurrentActivePlayer.Money;
    }

    public void RollDice()
    {
        _rolledDiceValue = UnityEngine.Random.Range(1, 7);
        if (CurrentActivePlayer)
        {
            Debug.Log($"Player: {CurrentActivePlayer.PlayerNumber} Rolled: {_rolledDiceValue}");
            // Get the new index for the player.
            var newPlayerBoardIndex = (CurrentActivePlayer.PositionOnBoardIndex + _rolledDiceValue) % 40;
            // Get the card at the new index.
            Space space = _gameBoard.GetSpaceAt(newPlayerBoardIndex);
            // Moving the player position on the board.
            // TODO: How are we going to get the position of where the player should go???
            CurrentActivePlayer.MovePositionTo(newPlayerBoardIndex, space.gameObject.transform.position);
            // Trigger for when the player lands on this space
            space.OnPlayerLand(CurrentActivePlayer);

            // TODO: Update the data on the playerUIData.

            if (space is PropertySpace)
            {
                PropertySpace propertySpace = (PropertySpace)space;
                _gameScreenUIData.UpdateNameOfPropertyBought(propertySpace.Data.Name);
                OnLandedOnPropertySpace?.Invoke((PropertySpace)space);
            }

            // Trigger an event that depends on the card type.
            // TODO: Call the correct strategy based on the card type.

            // Player has rolled the dice, but their turn is not over yet.
            _rolledAmount = _rolledDiceValue;
            _gameScreenUIData.UpdateRollAmount(_rolledAmount);
            OnDiceRolled?.Invoke();
        }
    }

    public void ChangeToNextPlayer()
    {
        var currentPlayer = _playersQueue.Dequeue();
        _playersQueue.Enqueue(currentPlayer);

        // Player turn is over after choosing to buy or not.
        OnPlayerTurnEnded?.Invoke();
        GameplayEvents.OnPlayerTurnEnded?.Invoke();
        _gameScreenUIData.ChangePlayerName(CurrentActivePlayer.Name);
        _gameScreenUIData.UpdateMoney(CurrentActivePlayer.Money);
        Debug.Log($"Player: {CurrentActivePlayer.PlayerNumber} Money: {CurrentActivePlayer.Money}");
    }

    // Gets called when you click yes on buy property panel? D:
    public void BuyProperty()
    {
        // Update the player money
        // Purchase the card that the player is currently on.
        // Move the behavior of Purchascing the property to the CanBuyStrategy.
        CurrentActivePlayer.PurchaseProperty(_gameBoard.GetSpaceAt(CurrentActivePlayer.PositionOnBoardIndex) is PropertySpace propertySpace ? propertySpace : null);
        Debug.Log($"Player: {CurrentActivePlayer.PlayerNumber} Money: {CurrentActivePlayer.Money}");
        OnBuyProperty?.Invoke(); //meak
        _gameScreenUIData.UpdateNameOfPropertyBought(CurrentActivePlayer.PropertiesOwned.Last().Data.Name);
        _gameScreenUIData.UpdateMoney(CurrentActivePlayer.Money);
    }
    
    void OnDestroy()
    {
        _gameData.Reset();
    }
}
