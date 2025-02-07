using UnityEngine;

public class ParkingSpace : Space
{
    [SerializeField] private ParkingSpaceData _data;
    public ParkingSpaceData Data => _data;
    public override void OnPlayerLand(Character character)
    {
        GameplayEvents.OnLandedOnParkingSpace?.Invoke(this);
    }
}
