using System;

public static class GameplayEvents
{
    public static Action OnRoll;
    public static Action OnPlayerTurnEnded;
    public static Action<PropertySpace> OnLandedOnPropertySpace;
    public static Action OnPropertyPurchased;
}
