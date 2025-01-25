using UnityEngine;

public class PlayerData
{
    public GameObject Character { get; private set; }
    public int PlayerNumber { get; private set; }

    public PlayerData(GameObject character, int playerNumber)
    {
        Character = character;
        PlayerNumber = playerNumber;
    }
}
