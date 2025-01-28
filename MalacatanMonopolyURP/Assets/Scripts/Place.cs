using UnityEngine;

public interface IPlayerLandStrategy
{
    public void Execute();
}
enum PlaceType
{
    Buyable,
    NonBuyable,
    Taxable,
    Jailable,
    Treasure
}

public class Place : MonoBehaviour
{
    [SerializeField] private string _placeName;
    [SerializeField] private GameObject _placeGO;
    [SerializeField] private float _price;
    [SerializeField] private PlaceType _placeType;
    private GameObject _playerSpotPositionGO;

    public GameObject PlaceGO => _placeGO;
    public Vector3 PlayersSpotPosition => _playerSpotPositionGO.transform.position;
    public string PlaceName => _placeName;
    public float Price => _price;

    public IPlayerLandStrategy PlaceStrategy { get; set; }

    void Start()
    {
        var parent = GameObject.FindGameObjectWithTag("PlayerSpots");
        _playerSpotPositionGO = parent.transform.Find($"{_placeName}Pos").gameObject;
        InitializeStrategy();
    }

    public void InitializeStrategy()
    {
        switch (_placeType)
        {
            case PlaceType.Buyable:
                PlaceStrategy = new BuyablePlaceStrategy();
                break;
            case PlaceType.NonBuyable:
                PlaceStrategy = new ParkablePlaceStrategy();
                break;
            case PlaceType.Taxable:
                PlaceStrategy = new TaxablePlaceStrategy();
                break;
            case PlaceType.Jailable:
                PlaceStrategy = new JailablePlaceStrategy();
                break;
            case PlaceType.Treasure:
                PlaceStrategy = new TreasurePlaceStrategy();
                break;
        }
    }

    public void UpdateLandStrategy(IPlayerLandStrategy strategy)
    {
        PlaceStrategy = strategy;
    }
}

public class BuyablePlaceStrategy: IPlayerLandStrategy
{
    public void Execute()
    {
        Debug.Log("Player landed on Buyable Place");
    }
}

public class ParkablePlaceStrategy: IPlayerLandStrategy
{
    public void Execute()
    {
        Debug.Log("Player landed on Non-Buyable Place");
    }
}   

public class TaxablePlaceStrategy: IPlayerLandStrategy
{
    public void Execute()
    {
        Debug.Log("Player landed on Taxable Place");
    }
}

public class JailablePlaceStrategy: IPlayerLandStrategy
{
    public void Execute()
    {
        Debug.Log("Player landed on Jailable Place");
    }
}

public class TreasurePlaceStrategy: IPlayerLandStrategy
{
    public void Execute()
    {
        Debug.Log("Player landed on Treasure Place");
    }
}