using UnityEngine;

public class GoPlace : Place
{
    protected override void Start()
    {
        base.Start();
        UpdateLandStrategy(new CanGoStrategy());
    }
}
