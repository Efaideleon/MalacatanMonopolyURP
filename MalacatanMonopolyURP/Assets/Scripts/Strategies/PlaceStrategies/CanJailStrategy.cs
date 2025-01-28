using UnityEngine;

public class CanJailStrategy: IOnLandStrategy
{
    public void Execute()
    {
        Debug.Log("Player landed on Jailable Place");
    }
}
