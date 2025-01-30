using UnityEngine;

public abstract class Place : MonoBehaviour
{
    public GameObject _playerSpotGo;

    public Vector3 PlayerSpotPosition => _playerSpotGo.gameObject.transform.position;
    public abstract void OnPlayerLand(Character character);
}
