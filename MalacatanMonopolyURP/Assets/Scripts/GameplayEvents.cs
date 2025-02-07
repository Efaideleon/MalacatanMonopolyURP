using System;

public static class GameplayEvents
{
    public static Action OnRoll;
    public static Action OnPlayerTurnEnded;
    public static Action OnPropertyPurchased;

    // On Landed events
    public static Action<PropertySpace> OnLandedOnPropertySpace;
    public static Action OnLandedOnTaxSpace;
    public static Action OnLandedOnJailSpace;
    public static Action OnLandedOnGoToJailSpace;
    public static Action OnLandedOnGoSpace;
    public static Action OnLandedOnChanceSpace;
    public static Action OnLandedOnParkingSpace;
    public static Action OnLandedOnTreasureSpace;
}
