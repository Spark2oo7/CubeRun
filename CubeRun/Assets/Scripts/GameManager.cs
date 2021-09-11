using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public bool testMode = true;
    public string gameId = "4206381";
    public string video = "Interstitial_Android";


    bool gameHasEnded = false;
    public float restartDelay;
    public float restartSceneDelay;
    public GameObject completeLevelUI;
    public GameObject restart;
    public AudioSource end;


    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
    }


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

        if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 1) % 20 == 0)
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Level", SceneManager.GetActiveScene().buildIndex - 1);

            Analytics.CustomEvent("Dead", data);


            if (Advertisement.IsReady())
            {
                Advertisement.Show(video);
            }
        }
    }

    public void CompleteLevel()
    {
        if (PlayerPrefs.GetInt("complete" + (SceneManager.GetActiveScene().buildIndex - 1), 0) == 0)
        {
            PlayerPrefs.SetInt("complete" + (SceneManager.GetActiveScene().buildIndex - 1), 1);

            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Level", SceneManager.GetActiveScene().buildIndex - 1);
            data.Add("Attempts", PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0).ToString());
            
            Analytics.CustomEvent("Level_complete", data);
        }

        completeLevelUI.SetActive(true);
    }
}
