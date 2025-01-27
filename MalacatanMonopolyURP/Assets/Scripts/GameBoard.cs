using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tiles;
    // Must be in order
    public List<GameObject> Tiles => _tiles;

    // Get the position of a tile at a specific index.
    public Vector3 GetTilePositionAt(int index)
    {
        for (int i = 0; i < _tiles.Count; i++)
        {
            if (i == index)
            {
                Debug.Log($"Tial at index {index} is : {_tiles[i].name}");
                Vector3 tilePosition = _tiles[i].transform.position;
                return tilePosition; 
            }
        }
        return Vector3.zero;
    }
}
