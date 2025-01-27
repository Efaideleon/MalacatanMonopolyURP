using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private List<GameObject> _positionMarkers;
    [SerializeField] private List<Card> _cards;

    // Must be in order
    public List<GameObject> PositionMarkers => _positionMarkers;

    // Get the position of a tile at a specific index.
    public Vector3 GetMarkerPositionAt(int index)
    {
        for (int i = 0; i < _positionMarkers.Count; i++)
        {
            if (i == index)
            {
                Debug.Log($"Marker at index {index} is : {_positionMarkers[i].name}");
                Vector3 markerPosition = _positionMarkers[i].transform.position;
                return markerPosition; 
            }
        }
        return Vector3.zero;
    }
}
