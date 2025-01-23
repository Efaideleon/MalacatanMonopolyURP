using UnityEngine;
using UnityEngine.UI;

public class GameMenu: MonoBehaviour
{
    [SerializeField] private GameObject StartMenu;
    [SerializeField] private GameObject NumOfPlayersMenu;
    [SerializeField] private GameObject CharacterSelectMenu;
    [SerializeField] private GameObject NumOfRoundsMenu;

    private int _numOfPlayers = 0;

    public void HandleStartButton()
    {
        // After the start button is clicked the number of players menu will be displayed
        if (NumOfPlayersMenu != null)
        {
            NumOfPlayersMenu.SetActive(true); 
        }
        else
        {
            Debug.LogWarning("NumOfPlayersMenu is not assigned!");
        }

        if (StartMenu != null)
        {
            StartMenu.SetActive(false);
        }
        else
        {
            Debug.LogWarning("StartMenu is not assigned!");
        }
    }

    public void PicknNumOfPlayers(int numOfPlayers)
    {
        _numOfPlayers = numOfPlayers;
    }   

    public void HandleConfirmNumOfPlayersButton()
    {
        Debug.Log($"Num of player picked: {_numOfPlayers}");
    }
}
