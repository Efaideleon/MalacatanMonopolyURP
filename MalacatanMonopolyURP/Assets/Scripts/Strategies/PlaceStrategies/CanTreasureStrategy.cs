using UnityEngine;

public class CanTreasureStrategy: IOnLandStrategy
{
    public void Execute()
    {
        Debug.Log("Player landed on Treasure Place");
    }
}