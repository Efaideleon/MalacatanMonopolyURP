using UnityEngine;

public class GoSpace : Space
{
    [SerializeField] private GoSpaceData _data;
    public GoSpaceData Data => _data;
    public override void OnPlayerLand(Character character)
    {
        GameplayEvents.OnLandedOnSpace?.Invoke(this);
    }
}
