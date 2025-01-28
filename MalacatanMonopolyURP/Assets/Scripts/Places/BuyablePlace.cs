using UnityEngine;

public class BuyablePlace : Place
{
    [SerializeField] private float _price;
    public float Price => _price;
    protected override void Start()
    {
        base.Start();
        UpdateLandStrategy(new CanBuyStrategy());
    }
}  
