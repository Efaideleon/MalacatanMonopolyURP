using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour , IComparable
{
    // Name of the character.
    [SerializeField] private string _name;
    public string Name => _name;

    // Name of the player to be displayed. 
    [SerializeField] private TextMeshProUGUI _playerNameText;

    // Number of the player
    public int PlayerNumber { get; private set; }

    public void InitializeCharacter(int playerNumber)
    {
        PlayerNumber = playerNumber;
        _playerNameText.text = $"Player {PlayerNumber}";
    }

    public int CompareTo(object obj)
    {
        if (obj == null) return 1;
        if (obj is Character otherCharacter)
        {
            return string.Compare(Name, otherCharacter.Name, StringComparison.Ordinal);
        }
        return 1;
    }
}
