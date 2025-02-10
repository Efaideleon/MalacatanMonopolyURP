using UnityEngine;

public class JailSpace : Space
{
    [SerializeField] private JailSpaceData _data;
    public JailSpaceData Data => _data;
    public override void OnPlayerLand(Character character)
    {
        GameplayEvents.OnLandedOnSpace?.Invoke(this);
    }
}
