using UnityEngine;

public class JailPlace : Space
{
    [SerializeField] private JailPlaceData _data;
    public override void OnPlayerLand(Character character)
    {
    }
}
