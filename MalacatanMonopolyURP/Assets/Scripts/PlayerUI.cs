using System;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _playerNameText;
    [SerializeField] private TextMeshProUGUI _rollAmountText;
    [SerializeField] private GameObject _rollAmountPanel;
    [SerializeField] private GameObject _buyMenu;
    [SerializeField] private GameObject _rollDiceButton;

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

    internal void UpdateRolledAmountText(int rolledAmount)
    {
        _rollAmountText.text = $"You Rolled: {rolledAmount}";
    }
}
