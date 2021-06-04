using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject restart;
    public float restartDelay;

    public void PlayLevel(string functions)
    {
        restart.SetActive(true);
        Invoke(functions, restartDelay);
    }

    public void Levels()
    {
        SceneManager.LoadScene(1);
    }

    public void Play()
    {
        int l = 0;
        while (PlayerPrefs.GetInt("complete" + (l+1), 0) == 1)
        {
            l++;
        }
        if (l == 15)
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(l + 2);
        }
    }
}
