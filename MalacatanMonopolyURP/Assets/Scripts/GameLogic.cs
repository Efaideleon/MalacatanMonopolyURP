using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

// Model
public class GameLogic : MonoBehaviour, INotifyPropertyChanged
{
    [Header("UI Elements")]
    [SerializeField] private GameData _gameData;
    [SerializeField] private GameBoard _gameBoard;
    [SerializeField] private CharacterSpawner _characterSpawner;
    [SerializeField] private GameScreenUIData _gameScreenUIData;

    private readonly ObservableQueue<Character> _playersQueue = new ();
    private int _rolledDiceValue = 0;
    private int _rolledAmount = 0;

    public Character CurrentActivePlayer => _playersQueue.Peek();
    public int RolledAmount => _rolledAmount; 
    public int RoundNumber { get; private set; }

    public event Action OnPlayerTurnEnded;
    public event Action OnPlayersQueueFilled;
    public event Action OnDiceRolled;
    public event Action OnBuyProperty;
    public event Action OnPlayersQueueChanged;
    public event PropertyChangedEventHandler PropertyChanged;

    void OnEnable()
    {
        if (_playersQueue == null)
        {
            Debug.Log("Players queue is empty");
        }
        _characterSpawner.OnAllCharactersSpawned += FillPlayersQueue;
        _playersQueue.CollectionChanged += HandlePlayersQueueChange;
        GameplayEvents.OnRoll += RollDice;
        GameplayEvents.OnPropertyPurchased += BuyProperty;
        GameplayEvents.OnLandedOnPropertySpace += UpdateGameScreenUIPropertyToBuyName;
    }

    void OnDisable()
    {
        _characterSpawner.OnAllCharactersSpawned -= FillPlayersQueue;
        _playersQueue.CollectionChanged -= HandlePlayersQueueChange;
        GameplayEvents.OnRoll -= RollDice;
        GameplayEvents.OnPropertyPurchased -= BuyProperty;
        GameplayEvents.OnLandedOnPropertySpace -= UpdateGameScreenUIPropertyToBuyName;
    }

    private void HandlePlayersQueueChange(object sender, NotifyCollectionChangedEventArgs e)
    {
        Debug.Log("HandlePlayersQueueChange");
        // When changing the queue unsubscribe all the previous elements and subscribe the new ones.
        if (e.OldItems != null)
        {
            foreach (INotifyPropertyChanged item in e.OldItems)
            {
                item.PropertyChanged -= CharacterInQueuePropertyChange;
            }
        }
        if (e.NewItems != null)
        {
            foreach (INotifyPropertyChanged item in e.NewItems)
            {
                item.PropertyChanged -= CharacterInQueuePropertyChange;
            }
        }
        OnPlayersQueueChanged?.Invoke();
    }

    private void UpdateGameScreenUIPropertyToBuyName(PropertySpace property)
    {
        _gameScreenUIData.UpdateNameOfPropertyToBuy(property.Data.Name);
    }

    private void CharacterInQueuePropertyChange(object sender, PropertyChangedEventArgs e)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(e.PropertyName)));
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
        /*_rolledDiceValue = UnityEngine.Random.Range(1, 7);*/
        _rolledDiceValue = 2;
        if (CurrentActivePlayer)
        {
            Debug.Log($"Player: {CurrentActivePlayer.PlayerNumber} Rolled: {_rolledDiceValue}");

            var newPlayerBoardIndex = (CurrentActivePlayer.PositionOnBoardIndex + _rolledDiceValue) % 40;
            Space space = _gameBoard.GetSpaceAt(newPlayerBoardIndex);

            CurrentActivePlayer.MovePositionTo(newPlayerBoardIndex, space.gameObject.transform.position);

            space.OnPlayerLand(CurrentActivePlayer);

            // Player has rolled the dice, but their turn is not over yet.
            _rolledAmount = _rolledDiceValue;
            _gameScreenUIData.UpdateRollAmount(_rolledAmount);
            OnDiceRolled?.Invoke();
        }
    }

    public void ChangeToNextPlayer()
    {
        // Check if we looped through the queue and increase the round number.
        if (CurrentActivePlayer.PlayerNumber == _playersQueue.Count)
        {
            RoundNumber++;
        }
        
        var currentPlayer = _playersQueue.Dequeue();
        Debug.Log($"Current Player number {currentPlayer.PlayerNumber}");
        _playersQueue.Enqueue(currentPlayer);

        // Player turn is over after choosing to buy or not.
        OnPlayerTurnEnded?.Invoke();
        GameplayEvents.OnPlayerTurnEnded?.Invoke();
        _gameScreenUIData.ChangePlayerName(CurrentActivePlayer.Name);
        Debug.Log($"Player: {CurrentActivePlayer.PlayerNumber} Money: {CurrentActivePlayer.Money}");
    }

    // Gets called when you click yes on buy property panel? D:
    private void BuyProperty()
    {
        Debug.Log("BuyProperty is getting called");
        // Update the player money
        // Purchase the card that the player is currently on.
        // Move the behavior of Purchascing the property to the CanBuyStrategy.
        
        
        CurrentActivePlayer.PurchaseProperty(_gameBoard.GetSpaceAt(CurrentActivePlayer.PositionOnBoardIndex) is PropertySpace propertySpace ? propertySpace : null);
        Debug.Log($"Player: {CurrentActivePlayer.PlayerNumber} Money: {CurrentActivePlayer.Money}");
        OnBuyProperty?.Invoke(); //meak
        // TODO: Removes this methods and bind the properties to the GameScreenUIData instead.
        _gameScreenUIData.UpdateNameOfPropertyBought(CurrentActivePlayer.PropertiesOwned.Last().Data.Name);
        _gameScreenUIData.UpdateMoney(CurrentActivePlayer.Money);
        
        
        // TODO:
        // Might Change this function to try to buy. If they dont' have enough money shouldn't buy
        // If they have enogh money show a pop up menu saying "You bought this property!"
        //ChangeToNextPlayer();
    }
    
    void OnDestroy()
    {
        _gameData.Reset();
    }

    public Space GetCurrentCharacterSpace()
    {
        return _gameBoard.GetSpaceAt(CurrentActivePlayer.PositionOnBoardIndex);
    }
}
