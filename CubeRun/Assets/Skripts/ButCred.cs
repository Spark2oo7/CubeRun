using UnityEngine;
using UnityEngine.SceneManagement;

public class ButCred : MonoBehaviour
{
    public GameObject restart;
    public float restartDelay;
    public void Credits()
    {
        restart.SetActive(true);
        Invoke("Restart", restartDelay);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings-1);
    }
}
