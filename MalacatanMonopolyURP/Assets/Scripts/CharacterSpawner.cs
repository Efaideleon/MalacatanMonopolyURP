using UnityEngine;
using System.Collections.Generic;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _characters;
    [SerializeField] GameMenu _gameMenu;

    void OnEnable()
    {
        _gameMenu.OnCharacterSpawn += SpawnCharacters;
    }

    void OnDisable()
    {
        _gameMenu.OnCharacterSpawn -= SpawnCharacters;
    }

    public void SpawnCharacters(List<string> charactersToSpawn)
    {
        foreach (var characterName in charactersToSpawn)
        {
            SpawnCharacter(characterName);
        }
    }
    
    private void SpawnCharacter(string characterName)
    {
        foreach (var character in _characters)
        {
            if (character.name == characterName)
            {
                Instantiate(character, transform.position, Quaternion.identity);
            }
        }
    }
}
