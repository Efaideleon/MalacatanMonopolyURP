using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    private List<string> _playerCharactersPicked = new List<string>();

    public void HandleStartButton()
    {
        ChangeMenu(StartMenu,NumOfPlayersMenu);
    }

    public void PickNumOfPlayers(int numOfPlayers)
    {
        _numOfPlayers = numOfPlayers;
    }   

    public void PickCharacter(string characterNameStr)
    {
        _chosenCharacterName = characterNameStr;
    }

    public void HandleConfirmCharacterSelection()
    {
        Debug.Log($"Player {_currentPlayerChoosingCharacter} picked: {_chosenCharacterName}");
        _playerCharactersPicked.Add(_chosenCharacterName);

        Debug.Log(_currentPlayerChoosingCharacter + " " + _numOfPlayers);
        if (_currentPlayerChoosingCharacter == _numOfPlayers)
        {
            // After finishing picking characters for all players go to num of rounds menu.
            ChangeMenu(CharacterSelectMenu, NumOfRoundsMenu);
        }
        _currentPlayerChoosingCharacter++;
        _currentPlayerChoosingCharacterText.text = _currentPlayerChoosingCharacter.ToString();
    }

    public void HandleConfirmNumOfPlayersButton()
    {
        Debug.Log($"Num of player picked: {_numOfPlayers}");
        ChangeMenu(NumOfPlayersMenu,CharacterSelectMenu);
    }

    public void ChangeMenu(GameObject currentMenu, GameObject nextMenu)
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
