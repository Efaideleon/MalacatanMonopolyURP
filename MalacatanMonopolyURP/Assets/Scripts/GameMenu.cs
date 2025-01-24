using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using UnityEngine.UI;

public class GameMenu: MonoBehaviour
{
    [Header("Menu Objects")] 
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject NumOfPlayersMenu;
    [SerializeField] private GameObject CharacterSelectMenu;
    [SerializeField] private GameObject NumOfRoundsMenu;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _currentPlayerChoosingCharacterText;
    [Tooltip("Characters available on the Character Selection Menu")]
    [SerializeField] private GameObject[] _charactersToChooseFrom;
    [SerializeField] private GameObject _numOfPlayersSelector;
    [SerializeField] private GameObject _characterSelector;
    [SerializeField] private GameObject _numOfRoundsSelector;

    // The number of players is set to 2 by default.
    private int _numOfPlayers = 2;
    private string _chosenCharacterName;  
    private int _currentPlayerChoosingCharacter = 1;
    private readonly List<string> _listOfCharacterPicked = new ();
    private int _numOfRounds = 8;

    // Events
    public event Action<List<string>> OnCharacterSpawn;

    void Start()
    {
        _chosenCharacterName = _charactersToChooseFrom[0].name;
    }

    public void PickNumOfPlayers(GameObject numOfPlayers)
    {
        _numOfPlayersSelector.transform.position = numOfPlayers.transform.position;
        _numOfPlayers = int.Parse(numOfPlayers.name);
    }   

    public void PickCharacter(GameObject CharacterName)
    {
        _characterSelector.transform.position = CharacterName.transform.position;
        _chosenCharacterName = CharacterName.name;
    }

    public void PickNumberOfRounds(GameObject RoundPanelNum)
    {
        _numOfRoundsSelector.transform.position = RoundPanelNum.transform.position;
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
            // If the chosenCharacterName is on the list of character picked return.
            if (_listOfCharacterPicked.Contains(_chosenCharacterName)) return;

            Debug.Log($"Player {_currentPlayerChoosingCharacter} picked: {_chosenCharacterName}");
            _listOfCharacterPicked.Add(_chosenCharacterName);

            // Set the chosen character button to inactive.
            Button characterButton = _charactersToChooseFrom.FirstOrDefault(character => _chosenCharacterName == character.name).GetComponent<Button>();
            characterButton.interactable = false;

            // Change to the next menu if all the players picked their characters.
            if (_currentPlayerChoosingCharacter == _numOfPlayers)
            {
                // After finishing picking characters for all players go to num of rounds menu.
                ChangeMenu(CharacterSelectMenu, NumOfRoundsMenu);
            }

            // TODO: The player should only be able to pick a unique character.
            _currentPlayerChoosingCharacter++;
            _currentPlayerChoosingCharacterText.text = _currentPlayerChoosingCharacter.ToString();

            // Set the selector to the next available character.
            GameObject nextAvailableCharacter = _charactersToChooseFrom.Where(character => !_listOfCharacterPicked.Contains(character.name)).FirstOrDefault();
            if (nextAvailableCharacter != null)
            {
                _characterSelector.transform.position = nextAvailableCharacter.transform.position;
                _chosenCharacterName = nextAvailableCharacter.name;
            }
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
                OnCharacterSpawn.Invoke(_listOfCharacterPicked);
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
