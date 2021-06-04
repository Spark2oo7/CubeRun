using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public GameObject restert;
    public float restartSceneDelay;
    public int loadLevel;
    public GameObject[] coButtons = new GameObject[15];
    public GameObject[] buttons = new GameObject[15];
    public GameObject[] noButtons = new GameObject[15];

    private void Start()
    {
        int complete = 3;
        for (int b = 1; b <= buttons.Length; b++)
        {
            if (PlayerPrefs.GetInt("complete"+b, 0) == 1)
            {
                buttons[b - 1].SetActive(false);
                noButtons[b - 1].SetActive(false);
            }
            else
            {
                if (complete > 0)
                {
                    complete --;
                    coButtons[b - 1].SetActive(false);
                    noButtons[b - 1].SetActive(false);
                }
                else
                {
                    buttons[b - 1].SetActive(false);
                    coButtons[b - 1].SetActive(false);
                }
            }
        }
    }
    public void StartLevel(int level)
    {
        loadLevel = level+1;
        restert.SetActive(true);
        Invoke("LoadLevel", restartSceneDelay);
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(loadLevel);
    }
}
