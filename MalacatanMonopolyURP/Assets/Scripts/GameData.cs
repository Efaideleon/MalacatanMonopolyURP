using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData")]
public class GameData : ScriptableObject
{
    [SerializeField] List<GameObject> _listOfAllCharacterGOs; 
    public List<GameObject> ListOfAllCharacterGOs => _listOfAllCharacterGOs;
    private List<Character> _listOfCharacersPicked = new ();
    public List<Character> ListOfCharactersPicked => _listOfCharacersPicked;
    public int NumberOfCharacters { get; private set; }

    // Events
    public event Action OnAllCharacterPicked;

    public void AddToCharactersPicked(Character character)
    {
        _listOfCharacersPicked.Add(character);

        Debug.Log("List of characters picked:");
        foreach(var c in _listOfCharacersPicked)
        {
            Debug.Log($"Character: {c.name}");
        }
    }

    public void SetTotalNumberOfCharacters(int numOfCharacters)
    {
        NumberOfCharacters = numOfCharacters;
        OnAllCharacterPicked?.Invoke();
    }

    public void Reset()
    {
        _listOfCharacersPicked.Clear();
    }
}
