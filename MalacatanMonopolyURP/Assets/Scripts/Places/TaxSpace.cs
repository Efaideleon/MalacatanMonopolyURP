using UnityEngine;

public class TaxSpace : Space
{
    [SerializeField] private TaxSpaceData _data;
    public TaxSpaceData Data => _data;
    public override void OnPlayerLand(Character character)
    {
        Debug.Log("Landed on tax!!!");
        GameplayEvents.OnLandedOnTaxSpace?.Invoke(this);
    }
}
