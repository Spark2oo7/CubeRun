using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject restart;
    public float restartDelay;
    public void Menu()
    {
        restart.SetActive(true);
        Invoke("Restart", restartDelay);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
