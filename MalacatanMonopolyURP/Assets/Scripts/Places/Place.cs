using UnityEngine;

public abstract class Space : MonoBehaviour
{
    public GameObject _playerSpotGo;

    public Vector3 PlayerSpotPosition => _playerSpotGo.gameObject.transform.position;
    public abstract void OnPlayerLand(Character character);
}
