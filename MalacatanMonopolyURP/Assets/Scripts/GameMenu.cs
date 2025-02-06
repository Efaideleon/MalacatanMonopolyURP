using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
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
    [SerializeField] private GameObject[] _panelsOfCharactersToChooseFrom;
    [SerializeField] private GameObject _numOfPlayersSelector;
    [SerializeField] private GameObject _characterSelector;
    [SerializeField] private GameObject _numOfRoundsSelector;

    // GameData stores informations about all the player's characters.
    [SerializeField] private GameData _gameData;

    // The number of players is set to 2 by default.
    private int _numOfPlayers = 2;
    private Character _chosenCharacter;  
    private int _numOfCurrentPlayerChoosingChar = 1;
    private int _numOfRounds = 8;

    // Events
    public event Action<List<Character>> OnAllCharactersPicked;

    void Start()
    {
        _gameData.Reset();
        _chosenCharacter = _gameData.ListOfAllCharacterGOs[0].GetComponent<Character>();
    }

    public void PickNumOfPlayers(GameObject numOfPlayers)
    {
        _numOfPlayersSelector.transform.position = numOfPlayers.transform.position;
        _numOfPlayers = int.Parse(numOfPlayers.name);
    }   

    public void PickCharacter(GameObject CharacterNamePanel)
    {
        _characterSelector.transform.position = CharacterNamePanel.transform.position;
        GameObject chosenCharacterGO = _gameData.ListOfAllCharacterGOs.FirstOrDefault(character => character.name == CharacterNamePanel.name);
        // if (chosenCharacterGO != null)
        _chosenCharacter = chosenCharacterGO.GetComponent<Character>();
        Debug.Log($"Character chosen: {_chosenCharacter.name}");
    }

    public void PickNumberOfRounds(GameObject RoundPanelNum)
    {
        _numOfRoundsSelector.transform.position = RoundPanelNum.transform.position;
        _numOfRounds = int.Parse(RoundPanelNum.name);
    }

    public void HandleStartButton()
    {
        Debug.Log("Start clicked...");
        ChangeMenu(StartMenu, NumOfPlayersMenu);
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
        Debug.Log($"Chosen character: {_chosenCharacter}");
        if (_chosenCharacter != null)
        {
            // The player should pick a unique character.
            foreach (Character c in _gameData.ListOfCharactersPicked)
            {
                Debug.Log($"{c}");
            }

            if (_gameData.ListOfCharactersPicked.Contains(_chosenCharacter)) return;

            Debug.Log($"Player {_numOfCurrentPlayerChoosingChar} picked: {_chosenCharacter.Name}");
            _chosenCharacter.InitializeCharacter(_numOfCurrentPlayerChoosingChar);

            // Set the chosen character button to inactive.
            GameObject chosenCharacterPanel = _panelsOfCharactersToChooseFrom.FirstOrDefault(characterPanel => _chosenCharacter.Name == characterPanel.name);
            Button chosenCharacterButton = chosenCharacterPanel.GetComponent<Button>();
            chosenCharacterButton.interactable = false;

            // Store the character picked in the GameData.
            _gameData.AddToCharactersPicked(_chosenCharacter);

            // Change to the next menu if all the players picked their characters.
            if (_numOfCurrentPlayerChoosingChar == _numOfPlayers)
            {
                // After finishing picking characters for all players go to num of rounds menu.
                ChangeMenu(CharacterSelectMenu, NumOfRoundsMenu);

                // Announce that all characters have been picked.
                _gameData.SetTotalNumberOfCharacters(_numOfPlayers);
            }

            _numOfCurrentPlayerChoosingChar++;
            _currentPlayerChoosingCharacterText.text = _numOfCurrentPlayerChoosingChar.ToString();

            // Set the selector to the next available character.
            GameObject nextAvailableCharacterPanel = _panelsOfCharactersToChooseFrom.FirstOrDefault(characterPanel => !_gameData.ListOfCharactersPicked.Any(pickedCharacter => pickedCharacter.Name == characterPanel.name));
            if (nextAvailableCharacterPanel != null)
            {
                _characterSelector.transform.position = nextAvailableCharacterPanel.transform.position;
                _chosenCharacter = _gameData.ListOfAllCharacterGOs.FirstOrDefault(characterGO => characterGO.GetComponent<Character>().Name == nextAvailableCharacterPanel.name).GetComponent<Character>();
            }
        }
        else
        {
            Debug.LogWarning("Character has not been picked!");
        }
    }

    // The last button pressed before starting the game.
    public void HandleStartButtonAfterNumOfRounds()
    {
        Debug.Log($"Num of rounds picked: {_numOfRounds}");
        if (_numOfRounds > 0) 
        {
            // Starting the game.
            Debug.Log("Starting the game...");
            if (NumOfRoundsMenu != null)
            {
                LoadGameScene();
                UnloadGameMenuScene();
                // TODO: Pass the character list to spawn
                /*OnAllCharactersPicked?.Invoke(_gameData.ListOfCharactersPicked);*/
            }
            else
            {
                Debug.LogWarning("Current menu is not assigned!");
            }
        }
    }

    private void UnloadGameMenuScene()
    {
        // Call the unity scenemanager to unload the current scene.
        // Load the game scene
        // TODO: Change to using async later.
        int gameMenuSceneIndex = 0;
        SceneManager.UnloadSceneAsync(gameMenuSceneIndex);
    }

    private void LoadGameScene()
    {
        int gameSceneIndex = 1;
        SceneManager.LoadSceneAsync(gameSceneIndex);
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
