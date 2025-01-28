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

    private List<Card> _propertiesOwned = new List<Card>();

    public void InitializeCharacter(int playerNumber)
    {
        PlayerNumber = playerNumber;
        _playerNameText.text = $"Player {PlayerNumber}";
    }

    public void MovePositionTo(int newBoardIndex, Vector3 position)
    {
        transform.position = position;
        PositionOnBoardIndex = newBoardIndex;
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

    public void PurchaseProperty(Card card)
    {
        Debug.Log($"1: Purchased: {card.CardName} for: {card.Price}");
        if (Money >= card.Price)
        {
            Debug.Log($"Purchased: {card.CardName} for: {card.Price}");
            Money -= card.Price;
            _propertiesOwned.Add(card);
        }
    }
}
