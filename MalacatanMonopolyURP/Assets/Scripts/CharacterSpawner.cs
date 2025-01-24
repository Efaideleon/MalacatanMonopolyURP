using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _characters;
    [SerializeField] GameMenu _gameMenu;

    void OnEnable()
    {
        // When the Start Button on the Round selection Menu is pressed spawn the Characters.
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
        // Find and check if the character exists in the list of available characters.
        GameObject characterToSpawn = _characters.FirstOrDefault(character => character.name == characterName);
        if (characterToSpawn != null)
        {
            Instantiate(characterToSpawn, transform.position, Quaternion.identity);
        }
    }
}
