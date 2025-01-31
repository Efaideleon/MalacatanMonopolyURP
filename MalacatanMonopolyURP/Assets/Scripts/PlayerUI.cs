using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _playerNameText;
    [SerializeField] private TextMeshProUGUI _rollAmountText;
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _youBoughtText;
    [SerializeField] private TextMeshProUGUI _propertyToBuyName;
    [SerializeField] private TextMeshProUGUI _propertyToBuyPrice;
    [SerializeField] private GameObject _rollAmountPanel;
    [SerializeField] private GameObject _buyMenu;
    [SerializeField] private GameObject _rollDiceButton;
    [SerializeField] private GameObject _youBoughtPanel;
    [SerializeField] private PlayerUIData _playerUIData;

    // Tax Menu
    // Treasure Menu
    // Chance Menu
    // Go Menu
    // Go To Jail Menu
    // Jail Menu

    private string _currencySymbol = "G";

    void OnEnable()
    {
        _playerUIData.OnPlayerNameChange += HandlePlayerNameChange;
        _playerUIData.OnMoneyChange += HandleMoneyChange;
        _playerUIData.OnNameOfPropertyBoughtChange += HandleNameOfPropertyBoughtChange;
        _playerUIData.OnRollAmountChange += HandleRollAmountChange;
        _playerUIData.OnBuyMenuPropertyNameChange += HandleBuyPropertyNameChange;
        _playerUIData.OnBuyMenuPropertyPriceChange += HandleBuyPropertyPriceChange;
    }

    void OnDisable()
    {
        _playerUIData.OnPlayerNameChange -= HandlePlayerNameChange;
        _playerUIData.OnMoneyChange -= HandleMoneyChange;
        _playerUIData.OnNameOfPropertyBoughtChange -= HandleNameOfPropertyBoughtChange;
        _playerUIData.OnRollAmountChange -= HandleRollAmountChange;
        _playerUIData.OnBuyMenuPropertyNameChange -= HandleBuyPropertyNameChange;
        _playerUIData.OnBuyMenuPropertyPriceChange -= HandleBuyPropertyPriceChange;
    }

    private void HandleBuyPropertyNameChange(string name)
    {
        _propertyToBuyName.text = name;
    }

    private void HandleBuyPropertyPriceChange(float price)
    {
        // TODO: Make the Symbol for currency be changed in a single place.
        _propertyToBuyPrice.text = $"{_currencySymbol}{price.ToString()}";
    }

    private void HandlePlayerNameChange(string name)
    {
        _playerNameText.text = $"Player: {name}";
    }

    private void HandleMoneyChange(float money)
    {
        _moneyText.text = $"Money: {_currencySymbol}{money}";
    }

    private void HandleNameOfPropertyBoughtChange(string name)
    {
        _youBoughtText.text = $"You Bought: {name}";
    }

    private void HandleRollAmountChange(int amount)
    {
        _rollAmountText.text = $"You Rolled: {amount}";
    }

    public void ShowBuyMenu()
    {
        _buyMenu.SetActive(true);
    }

    public void HideBuyMenu()
    {
        _buyMenu.SetActive(false);
    }

    public void ShowRollDiceButton()
    {
        _rollDiceButton.SetActive(true);
        _rollAmountPanel.SetActive(false);
    }

    public void HideRollDiceButton()
    {
        // After the player clicks on the roll buton, hide the roll button
        // and show the rolled number text.
        _rollDiceButton.SetActive(false);
        _rollAmountPanel.SetActive(true);
    }

    public void ShowYouBoughtPanel()
    {
        _youBoughtPanel.SetActive(true);
    }

    public void HideYouBoughtPanel()
    {
        _youBoughtPanel.SetActive(false);
    }
}
