using UnityEngine;

public class ParkingPlace : Space
{
    [SerializeField] private ParkingPlaceDataSO _data;
    public override void OnPlayerLand(Character character)
    {
    }
}
