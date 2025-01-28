using UnityEngine;

public class CanTaxStrategy: IOnLandStrategy
{
    public void Execute()
    {
        Debug.Log("Player landed on Taxable Place");
    }
}
