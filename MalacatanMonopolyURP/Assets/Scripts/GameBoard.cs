using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private List<Space> _spaces;

    // Get the card at a specific index.
    public Space GetSpaceAt(int index) => _spaces.ElementAtOrDefault(index);
}
