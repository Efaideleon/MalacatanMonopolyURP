using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

// Character ViewModel?
public class CurrentActivePlayer : INotifyPropertyChanged
{
    private Character _character;

    private void PurchaseProperty(PropertySpace space)
    {
        _character.PurchaseProperty(space);
    }
    public event PropertyChangedEventHandler PropertyChanged;

    public void Set(Character other)
    {
        _character = other;
    }
}
