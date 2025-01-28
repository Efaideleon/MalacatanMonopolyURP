using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private string _cardName;
    [SerializeField] private GameObject _cardGO;
    private GameObject _playerSpotPositionGO;

    public GameObject CardGO => _cardGO;
    public Vector3 PlayersSpotPosition => _playerSpotPositionGO.transform.position;
    public string CardName => _cardName;

    void Start()
    {
        var parent = GameObject.FindGameObjectWithTag("PlayerSpots");
        _playerSpotPositionGO = parent.transform.Find($"{_cardName}Pos").gameObject;
    }
}
