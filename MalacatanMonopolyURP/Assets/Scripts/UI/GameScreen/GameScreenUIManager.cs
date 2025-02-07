using System;
using System.ComponentModel;
using System.Data.SqlTypes;
using UnityEngine;

public class GameScreenUIManager : MonoBehaviour
{
    [SerializeField] private GameScreenUIData _gameScreenUIData;
    [SerializeField] private GameLogic _gameLogic;

    void OnEnable()
    {
        // TODO: Use the PropertyChange event from gameLogic instead
        // TODO: Bind the variable from character / gameLogic to gameScreenUIData instead of subscribing to events.
        _gameLogic.OnPlayersQueueChanged += UpdateGameScreenUIData;
        GameplayEvents.OnLandedOnPropertySpace += UpdateGameScreenPropertyToBuy;
        _gameLogic.OnDiceRolled += UpdateGameScreenRolledAmount; 
        _gameLogic.PropertyChanged += HandleGameLogicPropertyChange;
        //bind the gameLogic property changed to the variable in the scriptable object.
    }

    void OnDisable()
    {
        _gameLogic.OnPlayersQueueChanged -= UpdateGameScreenUIData;
        GameplayEvents.OnLandedOnPropertySpace -= UpdateGameScreenPropertyToBuy;
        _gameLogic.OnDiceRolled -= UpdateGameScreenRolledAmount; 
    }

    private void HandleGameLogicPropertyChange(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(_gameLogic.CurrentActivePlayer.Money))
        {
            _gameScreenUIData.Money = _gameLogic.CurrentActivePlayer.Money;
        }
    }

    private void UpdateGameScreenPropertyToBuy(PropertySpace space)
    {
        _gameScreenUIData.UpdateNameOfPropertyBought(space.Data.Name);
    }

    private void UpdateGameScreenUIData()
    {
        if (_gameLogic.CurrentActivePlayer != null)
        {
            _gameScreenUIData.ChangePlayerName(_gameLogic.CurrentActivePlayer.Name);
            _gameScreenUIData.UpdateMoney(_gameLogic.CurrentActivePlayer.Money);
        }
        else
        {
            Debug.LogError("CurrentActivePlayer is null");
        }
    }

    private void UpdateGameScreenRolledAmount()
    {
        _gameScreenUIData.UpdateRollAmount(_gameLogic.RolledAmount);
    }
}
