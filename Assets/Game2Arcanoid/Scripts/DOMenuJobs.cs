using UnityEngine;
using UnityEngine.SceneManagement;

public class DOMenuJobs : MonoBehaviour
{
    public void RestartButton()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
    
}
