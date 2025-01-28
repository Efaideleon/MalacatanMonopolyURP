using UnityEngine;

public class CanBuyStrategy: IOnLandStrategy
{
    public void Execute()
    {
        Debug.Log("Player landed on Buyable Place");
    }
}
