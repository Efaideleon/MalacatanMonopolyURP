using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _playerNameText;

    [Header("Game Logic")]
    [SerializeField] private GameLogic _gameLogic;

    void OnEnable()
    {
        _gameLogic.OnPlayerTurnChange += UpdatePlayerName;
    }

    private void UpdatePlayerName(int playerNumber)
    {
        _playerNameText.text = $"Player {playerNumber}";
    }
}
