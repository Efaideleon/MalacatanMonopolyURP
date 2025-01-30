using System;
using UnityEngine;

public class PropertySpace : Space
{
    [SerializeField] private PropertySpaceData _data;
    public PropertySpaceData Data => _data;
    public override void OnPlayerLand(Character character)
    {
    }
}