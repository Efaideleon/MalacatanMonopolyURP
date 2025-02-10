using UnityEngine;
using System.Collections.Generic;
using System;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] GameData _gameData;

    public event Action OnAllCharactersSpawned;

    void Start()
    {
        // When the Start Button on the Round selection Menu is pressed spawn the Characters.
        SpawnCharacters(_gameData.ListOfCharactersPicked);
    }

    public void SpawnCharacters(List<Character> charactersToSpawn)
    {
        float radius = 3f;
        for (int i = 0; i < charactersToSpawn.Count; i++)
        {
            // Calculate the angle in radians for this character
            float angle = i * Mathf.PI * 2 / charactersToSpawn.Count;

            // Calculate the position on the circle
            float x = transform.position.x + Mathf.Cos(angle) * radius;
            float z = transform.position.z + Mathf.Sin(angle) * radius;
            Vector3 charPos = new (x, transform.position.y, z);

            Quaternion charRot = Quaternion.Euler(0, 0, 0);
            SpawnCharacter(charactersToSpawn[i], charPos, charRot);
        }
        OnAllCharactersSpawned?.Invoke();
    }
    
    private void SpawnCharacter(Character characterToSpawn, Vector3 position, Quaternion rotation )
    {
        // Find and check if the character exists in the list of available characters.
        if (characterToSpawn != null)
        {
            var charInstance = Instantiate(characterToSpawn, position, rotation);
            charInstance.InitializeCharacter(characterToSpawn.PlayerNumber);
            _gameData.AddToInstancesOfCharactersPicked(charInstance);
        }
    }
}
