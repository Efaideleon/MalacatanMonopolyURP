public class ParkPlace : Place
{
    protected override void Start()
    {
        base.Start();
        UpdateLandStrategy(new CanParkStrategy());
    }
} 
