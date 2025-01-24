using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameMenu: MonoBehaviour
{
    [Header("Menu Objects")] 
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject NumOfPlayersMenu;
    [SerializeField] private GameObject CharacterSelectMenu;
    [SerializeField] private GameObject NumOfRoundsMenu;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _currentPlayerChoosingCharacterText;

    [SerializeField] private GameObject _num_of_players_selector;
    [SerializeField] private GameObject _character_selector;
    [SerializeField] private GameObject _num_of_rounds_selector;

    private int _numOfPlayers = 0;
    private string _chosenCharacterName = "";
    private int _currentPlayerChoosingCharacter = 1;
    private readonly List<string> _playerCharactersPicked = new ();
    private int _numOfRounds = 0;

    // Events
    public event Action<List<string>> OnCharacterSpawn;

    public void PickNumOfPlayers(GameObject numOfPlayers)
    {
        _num_of_players_selector.transform.position = numOfPlayers.transform.position;
        _numOfPlayers = int.Parse(numOfPlayers.name);
    }   

    public void PickCharacter(GameObject CharacterName)
    {
        _character_selector.transform.position = CharacterName.transform.position;
        _chosenCharacterName = CharacterName.name;
    }

    public void PickNumberOfRounds(GameObject RoundPanelNum)
    {
        _num_of_rounds_selector.transform.position = RoundPanelNum.transform.position;
        _numOfRounds = int.Parse(RoundPanelNum.name);
    }

    public void HandleStartButton()
    {
        ChangeMenu(StartMenu,NumOfPlayersMenu);
    }

    public void HandleConfirmNumOfPlayersButton()
    {
        Debug.Log($"Num of player picked: {_numOfPlayers}");
        // TODO: Make sure that the number has been picked before going to next menu.
        if (_numOfPlayers > 0)
        {
            ChangeMenu(NumOfPlayersMenu, CharacterSelectMenu);
        }
        else
        {
            Debug.LogWarning("Number of players has not been picked!");
        }
    }

    public void HandleConfirmCharacterSelection()
    {
        if (_chosenCharacterName != "")
        {
            Debug.Log($"Player {_currentPlayerChoosingCharacter} picked: {_chosenCharacterName}");
            _playerCharactersPicked.Add(_chosenCharacterName);

            if (_currentPlayerChoosingCharacter == _numOfPlayers)
            {
                // After finishing picking characters for all players go to num of rounds menu.
                ChangeMenu(CharacterSelectMenu, NumOfRoundsMenu);
            }



            // TODO: The player should only be able to pick a unique character.
            _currentPlayerChoosingCharacter++;
            _currentPlayerChoosingCharacterText.text = _currentPlayerChoosingCharacter.ToString();
            _chosenCharacterName = "";
        }
        else
        {
            Debug.LogWarning("Character has not been picked!");
        }
    }



    public void HandleStartButtonAfterNumOfRounds()
    {
        Debug.Log($"Num of rounds picked: {_numOfRounds}");
        if (_numOfRounds > 0) 
        {
            // Starting the game.
            Debug.Log("Starting the game...");
            gameObject.SetActive(false);
            if (NumOfRoundsMenu != null)
            {
                NumOfRoundsMenu.SetActive(false);
                // TODO: Pass the character list to spawn
                OnCharacterSpawn.Invoke(_playerCharactersPicked);
            }
            else
            {
                Debug.LogWarning("Current menu is not assigned!");
            }
        }
    }

    private void ChangeMenu(GameObject currentMenu, GameObject nextMenu)
    {
        
        if (currentMenu != null)
        {
            currentMenu.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Current menu is not assigned!");
        }

        if (nextMenu != null)
        {
            nextMenu.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Next menu is not assigned!");
        }
    }
}
