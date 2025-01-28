using UnityEngine;

public class CanGoStrategy : IOnLandStrategy
{
    public void Execute()
    {
        Debug.Log("You landed on Go! Collect 200$");
    }
}