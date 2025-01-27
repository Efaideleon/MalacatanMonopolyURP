using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _playerNameText;
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
    }

    public void HideRollDiceButton()
    {
        _rollDiceButton.SetActive(false);
    }
}
