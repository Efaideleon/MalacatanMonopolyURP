using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _playerNameText;

    public void UpdatePlayerName(int playerNumber)
    {
        Debug.Log($"Player Name Text: {playerNumber}");
        _playerNameText.text = $"Player {playerNumber}";
    }
}
