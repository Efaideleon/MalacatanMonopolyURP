using UnityEngine;

public class GameObjectId : MonoBehaviour
{
    [SerializeField] private int _id;
    public int Id => _id;
}