using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private List<GameObject> _positionMarkers;
    [SerializeField] private List<Space> _spaces;

    // Must be in order
    public List<GameObject> PositionMarkers => _positionMarkers;

    // Get the card at a specific index.
    public Space GetSpaceAt(int index) => _spaces.ElementAtOrDefault(index);
}
