using UnityEngine;

public class JailSpace : Space
{
    [SerializeField] private JailSpaceData _data;
    public override void OnPlayerLand(Character character)
    {
        GameplayEvents.OnLandedOnJailSpace?.Invoke();
    }
}
