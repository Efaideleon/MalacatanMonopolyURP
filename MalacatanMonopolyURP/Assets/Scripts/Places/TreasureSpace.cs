using UnityEngine;

public class TreasureSpace : Space
{
    [SerializeField] private TreasureSpaceData _data;
    public override void OnPlayerLand(Character character)
    {
        GameplayEvents.OnLandedOnTreasureSpace?.Invoke();
    }
}
