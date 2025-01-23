using UnityEngine;


public class PlayScreen : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;

    // This method is called when the button is pressed
    public void OnButtonPress()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true); // Enable the target GameObject
        }
        else
        {
            Debug.LogWarning("Target object is not assigned!");
        }
    }
}
