using System;

public static class GameplayEvents
{
    public static Action OnRoll;
    public static Action OnPlayerTurnEnded;
    public static Action OnPropertyPurchased;

    // On Landed events
    public static Action<PropertySpace> OnLandedOnPropertySpace;
    public static Action<TaxSpace> OnLandedOnTaxSpace;
    public static Action<JailSpace> OnLandedOnJailSpace;
    public static Action<GoToJailSpace> OnLandedOnGoToJailSpace;
    public static Action<GoSpace> OnLandedOnGoSpace;
    public static Action<ChanceSpace> OnLandedOnChanceSpace;
    public static Action<ParkingSpace> OnLandedOnParkingSpace;
    public static Action<TreasureSpace> OnLandedOnTreasureSpace;
}
