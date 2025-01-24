using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.ShaderGraph.Internal;

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

        float radius = 3f;
        for (int i = 0; i < charactersToSpawn.Count; i++)
        {
            // Calculate the angle in radians for this character
            float angle = i * Mathf.PI * 2 / charactersToSpawn.Count;

            // Calculate the position on the circle
            float x = transform.position.x + Mathf.Cos(angle) * radius;
            float z = transform.position.z + Mathf.Sin(angle) * radius;
            Vector3 charPos = new Vector3(x, transform.position.y, z);

            Quaternion charRot = Quaternion.Euler(0, 0, 0);
            SpawnCharacter(charactersToSpawn[i], charPos, charRot);
        }

    }
    
    private void SpawnCharacter(string characterName, Vector3 position, Quaternion rotation )
    {
        // Find and check if the character exists in the list of available characters.
        GameObject characterToSpawn = _characters.FirstOrDefault(character => character.name == characterName);
        if (characterToSpawn != null)
        {

            Instantiate(characterToSpawn, position, rotation);
        }
    }
}
