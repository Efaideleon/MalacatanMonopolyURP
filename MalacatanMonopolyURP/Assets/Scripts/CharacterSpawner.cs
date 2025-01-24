using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _characters;

    public void SpawnCharacters()
    {
        
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
