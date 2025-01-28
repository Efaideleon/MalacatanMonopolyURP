using UnityEngine;

public interface IOnLandStrategy
{
    public void Execute();
}

public class Place : MonoBehaviour
{
    [SerializeField] private string _placeName;
    [SerializeField] private GameObject _placeGO;
    private GameObject _playerSpotPositionGO;

    public GameObject PlaceGO => _placeGO;
    public Vector3 PlayersSpotPosition => _playerSpotPositionGO.transform.position;
    public string PlaceName => _placeName;

    public IOnLandStrategy PlaceStrategy { get; set; }

    protected virtual void Start()
    {
        var parent = GameObject.FindGameObjectWithTag("PlayerSpots");
        _playerSpotPositionGO = parent.transform.Find($"{_placeName}Pos").gameObject;
    }

    public void UpdateLandStrategy(IOnLandStrategy strategy)
    {
        PlaceStrategy = strategy;
    }
}