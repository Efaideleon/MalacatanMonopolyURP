using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class LoadPlacesJsonData : MonoBehaviour
{
    [SerializeField] private GameObject _buildings;

    void Start()
    {
        TextAsset placesJsonFile = Resources.Load<TextAsset>("placesData");

        if (placesJsonFile != null)
        {
            // Parse the data into the correct place type
            Debug.Log(placesJsonFile);
            PlacesList allPlaces = JsonUtility.FromJson<PlacesList>(placesJsonFile.text);
            Debug.Log("Printing....");

            // Add the place type object as a component to the Place GameObject
            
            Debug.Log(_buildings.transform.childCount);
            foreach (Transform building in _buildings.transform)
            {
                /* TODO: Are we reading from the json file??
                int buildingId = building.GetComponent<GameObjectId>().Id;
                Buyable buyablePlace = allPlaces.Buyable.FirstOrDefault(buildingObject => buildingObject.id == buildingId);
                // use the id to the find its info in the allPlaces PlacesList

                if (buyablePlace != null)
                {
                    // building.GetComponent<BuyablePlace>().PlayersSpotPosition = GetLandingSpotPosition(building.name);
                }
                */
            }
        }
        else
        {
            Debug.LogError("placesData not found!");
            return;
        }
    }

    private Vector3 GetLandingSpotPosition(string Name)
    {
        var parent = GameObject.FindGameObjectWithTag("PlayerSpots");
        Debug.Log($"{Name}");

        var landingSpot = parent.transform.Find($"{Name}Pos").gameObject;
        return landingSpot ? landingSpot.transform.position : Vector3.zero;
    }

    [System.Serializable]
    private class Buyable
    {
        public int id;
        public string name;
        public float price;
    }

    [System.Serializable]
    private class Treasure
    {
        public string id;
        public string name;
        public string[] cards; // Assuming 'cards' will contain an array of strings
    }

    [System.Serializable]
    private class Go
    {
        public string id;
        public string name;
        public int amount;
    }

    [System.Serializable]
    private class GoToJail
    {
        public string id;
        public string name;
    }

    [System.Serializable]
    private class Jail
    {
        public string id;
        public string name;
    }

    [System.Serializable]
    private class Parking
    {
        public string id;
        public string name;
    }

    [System.Serializable]
    private class Chance
    {
        public string id;
        public string name;
    }

    [System.Serializable]
    private class Tax
    {
        public string id;
        public string name;
        public int price; // Note: You have both 'price' and 'amount' in your JSON for Tax
        public int amount;
    }

    [System.Serializable]
    private class PlacesList
    {
        public Buyable[] Buyable;
        public Treasure[] Treasure;
        public Go[] Go;
        public GoToJail[] GoToJail;
        public Jail[] Jail;
        public Parking[] Parking;
        public Chance[] Chance;
        public Tax[] Tax;
    }
}
