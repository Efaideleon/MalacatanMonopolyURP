using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerUI", menuName = "Scriptable Objects/UI/PlayerUIData")]
public class GameScreenUIData : ScriptableObject
{
    // Each of this properties is binded to the Gamescreen.uxml components
    [SerializeField] public string PlayerName;
    [SerializeField] public int RollAmount; 
    [SerializeField] public float Money; 
    [SerializeField] public string NameOfPropertyToBuy;
    [SerializeField] public float PriceOfPropertyToBuy;
    [SerializeField] public string NameOfPropertyBought; 

    public event Action<string> OnPlayerNameChange;
    public event Action<int> OnRollAmountChange;
    public event Action<float> OnMoneyChange;
    public event Action<string> OnNameOfPropertyBoughtChange;
    public event Action<string> OnBuyMenuPropertyNameChange;
    public event Action<float> OnBuyMenuPropertyPriceChange;

    public void ChangePlayerName(string playerName)
    {
        PlayerName = playerName;
        OnPlayerNameChange?.Invoke(PlayerName);
    }
    
    public void UpdateRollAmount(int rollAmount)
    {
        RollAmount = rollAmount;
        OnRollAmountChange?.Invoke(RollAmount);
    }

    public void UpdateMoney(float money)
    {
        Money = money;
        OnMoneyChange?.Invoke(Money);
    }

    public void UpdateNameOfPropertyBought(string name)
    {
        NameOfPropertyBought = name;
        OnNameOfPropertyBoughtChange?.Invoke(NameOfPropertyBought);
    }

    public void UpdateNameOfPropertyToBuy(string name)
    {
        NameOfPropertyToBuy = name;
        OnBuyMenuPropertyNameChange?.Invoke(name);
    }

    public void UpdatePriceOfPropertyToBuy(float price)
    {
        PriceOfPropertyToBuy = price;
        OnBuyMenuPropertyPriceChange?.Invoke(price);
    }
}
