using UnityEngine.UIElements;
using System.Collections.Generic;
using System;
using UnityEngine;

// Controls all the pop up windows excpet for buy menu, and you bought popup
public class GameScreenUI
{
    private readonly Dictionary<Type, List<string>> _spaceToUIDataDictionary;
    private readonly Dictionary<Type, AlertPopUp> _spaceToAlertPopUp;
    private Dictionary<Type, Func<Space, string>> _typeToLabelGeneratorDictionary;
    private List<Type> _listOfSpaceTypes;
    private readonly VisualElement _root;
    private GameLogic _gameLogic;

    public GameScreenUI(VisualElement root, GameLogic gameLogic)
    {
        _root = root;
        _gameLogic = gameLogic;
        _listOfSpaceTypes = new ()
        {
            typeof(TaxSpace),
            typeof(JailSpace),
            typeof(GoToJailSpace),
            typeof(GoSpace),
            typeof(ChanceSpace),
            typeof(TreasureSpace),
            typeof(ParkingSpace), 
        };

        _spaceToUIDataDictionary = new()
        {
            { typeof(TaxSpace) , new List<string>() { "tax-display-container",  "tax-panel-label", "tax-panel-button"} },
            { typeof(JailSpace) , new List<string>() { "jail-display-container", "jail-panel-label", "jail-panel-button"} },
            { typeof(GoToJailSpace) , new List<string>() { "go-to-jail-display-container", "go-to-jail-panel-label", "go-to-jail-panel-button"} },
            { typeof(GoSpace) , new List<string>() { "go-display-container", "go-panel-label", "go-panel-button"} },
            { typeof(ChanceSpace) , new List<string>() { "chance-display-container", "chance-panel-label", "chance-panel-button"} },
            { typeof(TreasureSpace) , new List<string>() { "treasure-display-container", "treasure-panel-label", "treasure-panel-button"} },
            { typeof(ParkingSpace) , new List<string>() { "parking-display-container", "parking-panel-label", "parking-panel-button"} },
        };

        _typeToLabelGeneratorDictionary = new()
        {
            { typeof(TaxSpace), space => $"You were taxed {((TaxSpace)space).Data.TaxAmount}" },
            { typeof(JailSpace), space => $"You are in jail for 1 turn!" },
            { typeof(GoToJailSpace), space => "Go to Jail" },
            { typeof(GoSpace), space => $"go idk"},
            { typeof(ChanceSpace), space => $"chance idk" },
            { typeof(TreasureSpace), space => $"treasure idk" },
            { typeof(ParkingSpace), space => $"parking idk" },
        };

        _spaceToAlertPopUp = new();
        InitializeSpaceToAlertPopUpDictionary(_root);
        SubscribesPopToOnLandEvents();
    }

    private void InitializeSpaceToAlertPopUpDictionary(VisualElement root)
    {
        foreach (var spaceType in _listOfSpaceTypes)
        {
            if (_spaceToUIDataDictionary.TryGetValue(spaceType, out var listOfClassNames))
            {
                string containerClassName = listOfClassNames[0];
                string labelClassName = listOfClassNames[1];
                string buttonClassName = listOfClassNames[2];

                _spaceToAlertPopUp.Add(spaceType, new AlertPopUp(
                        root, 
                        containerClassName,
                        buttonClassName,
                        labelClassName,
                        _gameLogic
                ));
            }
        }
    }

    private void SubscribesPopToOnLandEvents() => GameplayEvents.OnLandedOnSpace += Show; 
    private void UnSubscribeFromOnLandEvents() => GameplayEvents.OnLandedOnSpace -= Show;

    private void Show(Space space)
    {
        var spaceType = space.GetType();
        string label; 
        if (_typeToLabelGeneratorDictionary.TryGetValue(spaceType, out var generateLabel))
        {
            label = generateLabel.Invoke(space);
            if (_spaceToAlertPopUp.TryGetValue(spaceType, out var alertPopUp))
                alertPopUp.Show(label);
        }
    }

    public void Dispose()
    {
        foreach(var popUp in _spaceToAlertPopUp.Values)
            popUp.Dispose();

        UnSubscribeFromOnLandEvents();
    }
}
