using UnityEngine;

public class ChancePlace : Space
{
    [SerializeField] private ChancesSpaceData _data;
    public override void OnPlayerLand(Character character)
    {
        GameplayEvents.OnLandedOnChanceSpace?.Invoke();
    }
}
