using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // This method will be called when the button is clicked to load the next scene
    public void LoadNextScene()
    {
        // Get the current scene's index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;


        // Calculate the next scene's index
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene exists in the build settings
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // If there is no next scene, print a message
            Debug.Log("No next scene available.");
        }
        
    }
    public void LoadMainScreen(int sceneIndex)
    {
        string currentSceneName = SceneManager.GetActiveScene().name;

            SceneManager.LoadScene(0);
        
    }
}
