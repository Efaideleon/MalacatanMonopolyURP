public class TreasurePlace : Place
{
    protected override void Start()
    {
        base.Start();
        UpdateLandStrategy(new CanTreasureStrategy());
    }
}
