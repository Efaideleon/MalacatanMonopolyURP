using UnityEngine;

public class TreasureSpace : Space
{
    [SerializeField] private TreasureSpaceData _data;
    public TreasureSpaceData Data => _data;
    public override void OnPlayerLand(Character character)
    {
        Debug.Log("Landed on Treasure");
        GameplayEvents.OnLandedOnTreasureSpace?.Invoke(this);
    }
}
