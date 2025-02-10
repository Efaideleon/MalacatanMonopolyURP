using UnityEngine;

public class GoToJailSpace : Space
{
    [SerializeField] private GoToJailSpaceData _data;
    public GoToJailSpaceData Data => _data;
    public override void OnPlayerLand(Character character)
    {
        GameplayEvents.OnLandedOnSpace?.Invoke(this);
    }
}
