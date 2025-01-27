using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData")]
public class GameData : ScriptableObject
{
    [SerializeField] List<GameObject> _listOfAllCharacterGOs; 
    public List<GameObject> ListOfAllCharacterGOs => _listOfAllCharacterGOs;
    private List<Character> _listOfCharacersPicked = new();
    public List<Character> ListOfCharactersPicked => _listOfCharacersPicked;
    private List<Character> _listOfInstancesOfCharactersPicked = new();
    public List<Character> ListOfInstancesOfCharactersPicked => _listOfInstancesOfCharactersPicked;
    public int NumberOfCharacters { get; private set; }

    public void AddToCharactersPicked(Character character)
    {
        _listOfCharacersPicked.Add(character);

        Debug.Log("List of characters picked:");
        foreach(var c in _listOfCharacersPicked)
        {
            Debug.Log($"Character: {c.name}");
        }
    }

    public void AddToInstancesOfCharactersPicked(Character character)
    {
        _listOfInstancesOfCharactersPicked.Add(character);
        Debug.Log($"Adding Character instance: {character.Name}");
        foreach(var c in _listOfInstancesOfCharactersPicked)
        {
            Debug.Log($"Character: {c.name}");
        }
    }

    public void SetTotalNumberOfCharacters(int numOfCharacters)
    {
        NumberOfCharacters = numOfCharacters;
    }

    public void Reset()
    {
        _listOfCharacersPicked.Clear();
        _listOfInstancesOfCharactersPicked.Clear();
    }
}
