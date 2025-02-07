using UnityEngine;

public class TaxSpace : Space
{
    [SerializeField] private TaxSpaceData _data;
    public override void OnPlayerLand(Character character)
    {
        GameplayEvents.OnLandedOnTaxSpace?.Invoke();
    }
}
