using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("UI Elements")]
    // [SerializeField] private TextMeshProUGUI _playerNameText;
    // [SerializeField] private TextMeshProUGUI _rollAmountText;
    // [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _youBoughtText;
    [SerializeField] private TextMeshProUGUI _propertyToBuyName;
    [SerializeField] private TextMeshProUGUI _propertyToBuyPrice;
    // [SerializeField] private GameObject _rollAmountPanel;
    [SerializeField] private GameObject _buyMenu;
    // [SerializeField] private GameObject _rollDiceButton;
    [SerializeField] private GameObject _youBoughtPanel;
    [SerializeField] private GameScreenUIData _playerUIData;

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
        // _propertyToBuyName.text = name;
    }

    private void HandleBuyPropertyPriceChange(float price)
    {
        // TODO: Make the Symbol for currency be changed in a single place.
        // _propertyToBuyPrice.text = $"{_currencySymbol}{price.ToString()}";
    }

    private void HandlePlayerNameChange(string name)
    {
        // Replaced by UI Toolkit
        // _playerNameText.text = $"Player: {name}";
    }

    private void HandleMoneyChange(float money)
    {
        // Replaced by UI Toolkit
        // _moneyText.text = $"Money: {_currencySymbol}{money}";
    }

    private void HandleNameOfPropertyBoughtChange(string name)
    {
        _youBoughtText.text = $"You Bought: {name}";
    }

    private void HandleRollAmountChange(int amount)
    {
    }

    public void ShowBuyMenu()
    {
        // _buyMenu.SetActive(true);
    }

    public void HideBuyMenu()
    {
        // _buyMenu.SetActive(false);
    }

    public void ShowRollDiceButton()
    {
    }

    public void HideRollDiceButton()
    {
        // After the player clicks on the roll buton, hide the roll button
        // and show the rolled number text.
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
