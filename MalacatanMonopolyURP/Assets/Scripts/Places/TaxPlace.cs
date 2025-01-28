using UnityEngine;

public class TaxPlace : Place
{
    [SerializeField] private float _taxAmount;
    protected override void Start()
    {
        base.Start();
        UpdateLandStrategy(new CanTaxStrategy());
    }
}
