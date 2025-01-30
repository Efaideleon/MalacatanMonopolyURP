using UnityEngine;

public class JailPlace : Place
{
    [SerializeField] private JailPlaceDataSO _data;
    public override void OnPlayerLand(Character character)
    {
    }
}
