using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

// Character Model
public class Character : MonoBehaviour , IComparable, INotifyPropertyChanged
{
    // Name of the character.
    [SerializeField] private string _name;
    public string Name => _name;

    // Name of the player to be displayed. 
    [SerializeField] private TextMeshProUGUI _playerNameText;

    // Number of the player
    public int PlayerNumber { get; private set; }
    public int PositionOnBoardIndex { get; private set; } = 0; 
    private float _money = 500_000;
    public float Money 
    { 
        get => _money;
        set
        {
            _money = value;
            OnPropertyChanged(nameof(Money));
        }
    }

    private List<PropertySpace> _propertiesOwned = new List<PropertySpace>();
    public List<PropertySpace> PropertiesOwned => _propertiesOwned;
    private Vector3 _startPosition;
    private Vector3 _targetPosition;

    private float _travelDuration = 2f;
    private float _timeElapsed = 0f;

    public event PropertyChangedEventHandler PropertyChanged;

    public bool IsMoving { get; set; } = false;

    void Update()
    {
    }

    public void InitializeCharacter(int playerNumber)
    {
        PlayerNumber = playerNumber;
        _playerNameText.text = $"Player {PlayerNumber}";
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void MovePositionTo(int newBoardIndex, Vector3 targetPosition)
    {
        Debug.Log($"Moving Character {Name}");
        Debug.Log($"Current Postion: {transform.position}");
        Debug.Log($"Target Position: {targetPosition}");
        // Set the new target position 
        _startPosition = transform.position;
        _targetPosition = targetPosition;
        PositionOnBoardIndex = newBoardIndex;
        StartCoroutine(MoveCharacter());
    }

    private IEnumerator MoveCharacter()
    {
        _startPosition = transform.position;

        while (_timeElapsed < _travelDuration)
        {
            _timeElapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(_startPosition, _targetPosition, _timeElapsed / _travelDuration); 
            IsMoving = true;
            yield return null;
        }
        IsMoving = false; // Bogus:
        _timeElapsed = 0;
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
