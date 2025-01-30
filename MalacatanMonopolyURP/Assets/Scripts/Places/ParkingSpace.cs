using UnityEngine;

public class ParkingSpace : Space
{
    [SerializeField] private ParkingSpaceData _data;
    public override void OnPlayerLand(Character character)
    {
    }
}
