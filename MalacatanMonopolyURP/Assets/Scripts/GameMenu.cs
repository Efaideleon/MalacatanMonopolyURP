using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMenu: MonoBehaviour
{
    [Header("Menu Objects")] 
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject NumOfPlayersMenu;
    [SerializeField] private GameObject CharacterSelectMenu;
    [SerializeField] private GameObject NumOfRoundsMenu;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _currentPlayerChoosingCharacterText;

    private int _numOfPlayers = 0;
    private string _chosenCharacterName = "";
    private int _currentPlayerChoosingCharacter = 1;
    private readonly List<string> _playerCharactersPicked = new ();
    private int _numOfRounds = 0;

    public void PickNumOfPlayers(int numOfPlayers)
    {
        _numOfPlayers = numOfPlayers;
    }   

    public void PickCharacter(string characterNameStr)
    {
        _chosenCharacterName = characterNameStr;
    }

    public void PickNumberOfRounds(int numOfRounds)
    {
        _numOfRounds = numOfRounds;
    }

    public void HandleStartButton()
    {
        ChangeMenu(StartMenu,NumOfPlayersMenu);
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

    public void HandleStartButtonAfterNumOfRounds()
    {
        Debug.Log($"Num of rounds picked: {_numOfRounds}");
        if (_numOfRounds > 0) 
        {
            Debug.Log("Starting the game...");
            gameObject.SetActive(false);
            if (NumOfRoundsMenu != null)
            {
                NumOfRoundsMenu.SetActive(false);
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
