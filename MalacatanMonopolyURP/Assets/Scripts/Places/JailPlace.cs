public class JailPlace : Place
{
    protected override void Start()
    {
        base.Start();
        UpdateLandStrategy(new CanJailStrategy());
    }
}
