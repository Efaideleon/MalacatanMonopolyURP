using UnityEngine;

public class JailPlace : Space
{
    [SerializeField] private JailPlaceDataSO _data;
    public override void OnPlayerLand(Character character)
    {
    }
}
