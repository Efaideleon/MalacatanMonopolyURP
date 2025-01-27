using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] private GameLogic _gameLogic;
    private UnityEngine.Camera _camera;

    void Start()
    {
        _camera = GetComponent<UnityEngine.Camera>();
    }

    void OnEnable()
    {
        _gameLogic.OnPlayersQueueFilled += HandleGameStart;
        // When the player rolls the dice, make the camera look at that current player on their new position.
        _gameLogic.OnDiceRolled += UpdateCameraPosition;
        // When the player turn ends, make the camera look at the next player.
        _gameLogic.OnPlayerTurnEnded += UpdateCameraPosition;
    }

    void OnDisable()
    {
        _gameLogic.OnPlayersQueueFilled -= HandleGameStart;
        _gameLogic.OnDiceRolled -= UpdateCameraPosition;
        _gameLogic.OnPlayerTurnEnded -= UpdateCameraPosition;
    }

    private void HandleGameStart()
    {}

    // Make the camera look at the current active player.
    private void UpdateCameraPosition()
    {
        if (_gameLogic.CurrentActivePlayer)
        {
            var offset = CalculateOffset();
            transform.position = _gameLogic.CurrentActivePlayer.transform.position + offset;
            _camera.transform.LookAt(_gameLogic.CurrentActivePlayer.transform);
        }
    }

    private Vector3 CalculateOffset()
    {
        switch (_gameLogic.CurrentActivePlayer.PositionOnBoardIndex)
        {
            case < 10:
                return new Vector3(20, 15, 5);
            case >= 10 and < 20:
                return new Vector3(-5, 15, -20);
            case >= 20 and < 30:
                return new Vector3(-20, 15, -5);
            case >= 30:
                return new Vector3(5, 15, 20);
        }
    }
}
