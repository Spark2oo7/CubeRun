using UnityEngine;
using UnityEngine.SceneManagement;

public class ButSett : MonoBehaviour
{
    public GameObject restart;
    public float restartDelay;
    public void Settings()
    {
        restart.SetActive(true);
        Invoke("Restart", restartDelay);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings-1);
    }
}
