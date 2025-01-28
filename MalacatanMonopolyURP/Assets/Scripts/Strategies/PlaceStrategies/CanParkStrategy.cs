using UnityEngine;

public class CanParkStrategy: IOnLandStrategy
{
    public void Execute()
    {
        Debug.Log("Player landed on Non-Buyable Place");
    }
}   
