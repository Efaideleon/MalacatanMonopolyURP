using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Character : MonoBehaviour , IComparable
{
    // Name of the character.
    [SerializeField] private string _name;
    public string Name => _name;

    // Name of the player to be displayed. 
    [SerializeField] private TextMeshProUGUI _playerNameText;

    // Number of the player
    public int PlayerNumber { get; private set; }
    public int PositionOnBoardIndex { get; private set; } = 0; 
    public float Money { get; private set; } = 500_000;

    private List<PropertySpace> _propertiesOwned = new List<PropertySpace>();
    public List<PropertySpace> PropertiesOwned => _propertiesOwned;

    public void InitializeCharacter(int playerNumber)
    {
        PlayerNumber = playerNumber;
        _playerNameText.text = $"Player {PlayerNumber}";
    }

    public void MovePositionTo(int newBoardIndex, Vector3 position)
    {
        // Moves the player to a position
        transform.position = position;
        PositionOnBoardIndex = newBoardIndex;
    }

    public void PurchaseProperty(PropertySpace property)
    {
        Debug.Log($"Property Bought: {property}");
        _propertiesOwned.Add(property);
        Money -= property.Data.price;
        //:( meak meak meak meak 
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
