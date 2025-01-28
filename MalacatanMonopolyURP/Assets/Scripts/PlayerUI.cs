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
    [SerializeField] private GameObject _rollAmountPanel;
    [SerializeField] private GameObject _buyMenu;
    [SerializeField] private GameObject _rollDiceButton;
    [SerializeField] private GameObject _youBoughtPanel;

    public void UpdatePlayerName(int playerNumber)
    {
        Debug.Log($"Player Name Text: {playerNumber}");
        _playerNameText.text = $"Player {playerNumber}";
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

    public void UpdateRolledAmountText(int rolledAmount)
    {
        _rollAmountText.text = $"You Rolled: {rolledAmount}";
    }

    public void UpdateMoneyText(float money)
    {
        _moneyText.text = $"Money: {money}";
    }

    public void ShowYouBoughtPanel(string cardName)
    {
        _youBoughtText.text = $"You bought: {cardName}";
        _youBoughtPanel.SetActive(true);
    }

    public void HideYouBoughtPanel()
    {
        _youBoughtPanel.SetActive(false);
    }
}
