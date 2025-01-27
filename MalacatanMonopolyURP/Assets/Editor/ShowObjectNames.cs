// using UnityEditor;
// using UnityEngine; 

// [InitializeOnLoad] public class ShowObjectNames 
// {     
//     static ShowObjectNames()     
//     {         
//         SceneView.duringSceneGui += OnSceneGUI;     
//     }      
//     private static void OnSceneGUI(SceneView sceneView)     
//     {         
//         // Iterate over all GameObjects in the scene
//         foreach (GameObject obj in Object.FindObjectsByType<GameObject>(FindObjectsSortMode.None))
//         {             
//             // Skip objects that aren't active
//             if (!obj.activeInHierarchy) continue;              
//             // Get the position of the object             
//             Vector3 worldPosition = obj.transform.position;             
//             Vector3 screenPosition = sceneView.camera.WorldToScreenPoint(worldPosition);              
//             // Skip objects that are behind the camera
//             if (screenPosition.z < 0) continue;              
//             // Convert world position to GUI position             
//             Vector2 guiPosition = new Vector2(screenPosition.x, sceneView.position.height - screenPosition.y);              
//             Handles.BeginGUI();             
//             GUI.color = Color.white;
//             GUIStyle style = new GUIStyle(GUI.skin.label);
//             style.alignment = TextAnchor.LowerCenter; // Center text below the point
//             style.fontSize = 12; // Adjust font size if needed
//             style.fontStyle = FontStyle.Bold; // Optional: Make text bold

//             // Display the name
//             GUI.Label(new Rect(guiPosition.x - 50, guiPosition.y, 100, 20), obj.name, style); // Center the label horizontally
//             Handles.EndGUI();         
//         } 
//     }
// }