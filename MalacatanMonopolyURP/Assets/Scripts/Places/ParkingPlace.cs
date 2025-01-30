using UnityEngine;

public class ParkingPlace : Space
{
    [SerializeField] private ParkingPlaceData _data;
    public override void OnPlayerLand(Character character)
    {
    }
}
