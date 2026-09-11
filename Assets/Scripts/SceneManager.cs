using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings - 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
