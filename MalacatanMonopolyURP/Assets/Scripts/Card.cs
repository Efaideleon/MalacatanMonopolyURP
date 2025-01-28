using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private string _cardName;
    [SerializeField] private GameObject _cardGO;
    [SerializeField] private float _price;
    private GameObject _playerSpotPositionGO;

    public GameObject CardGO => _cardGO;
    public Vector3 PlayersSpotPosition => _playerSpotPositionGO.transform.position;
    public string CardName => _cardName;
    public float Price => _price;

    void Start()
    {
        var parent = GameObject.FindGameObjectWithTag("PlayerSpots");
        _playerSpotPositionGO = parent.transform.Find($"{_cardName}Pos").gameObject;
    }
}
