using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData")]
public class GameData : ScriptableObject
{
    [SerializeField] List<GameObject> _listOfAllCharacterGOs; 
    public List<GameObject> ListOfAllCharacterGOs => _listOfAllCharacterGOs;
    private List<Character> _charactersPlaying = new ();

    public void SetCharacters(List<Character> characters)
    {
        _charactersPlaying = characters;
    }
}
