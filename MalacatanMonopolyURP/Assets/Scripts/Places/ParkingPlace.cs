using UnityEngine;

public class ParkingPlace : Place
{
    [SerializeField] private ParkingPlaceDataSO _data;
    public override void OnPlayerLand(Character character)
    {
    }
}
