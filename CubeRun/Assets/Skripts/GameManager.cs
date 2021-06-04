using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Monetization;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay;
    public float restartSceneDelay;
    public GameObject completeLevelUI;
    public GameObject restart;
    public AudioSource end;

    //[System.Obsolete]
    //private void Start()
    //{
        //if (Monetization.issupported)
        //{
        //    Monetization.initialize("4122969", false);
        //}
    //}


    public void EndGame ()
    {
        if (!gameHasEnded)
        {
            end.Play();
            gameHasEnded = true;
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0) + 1);
            Invoke("Restart", restartDelay);
        }
    }

    private void Restart()
    {
        restart.SetActive(true);
        Invoke("RestartScene", restartSceneDelay);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel()
    {
        PlayerPrefs.SetInt("complete" + (SceneManager.GetActiveScene().buildIndex - 1), 1);
        completeLevelUI.SetActive(true);
        //if (Monetization.isready())
        //{
        //    Monetization.show("video");
        //    print("qwerty");
        //}
    }
}
