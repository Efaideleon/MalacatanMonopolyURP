using UnityEngine;

public class ChanceSpace : Space
{
    [SerializeField] private ChancesSpaceData _data;
    public ChancesSpaceData Data => _data;
    public override void OnPlayerLand(Character character)
    {
        GameplayEvents.OnLandedOnChanceSpace?.Invoke(this);
    }
}
