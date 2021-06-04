using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public Text levelText;
    public GameObject cube;
    public Material gold;

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelNumber()
    {
        if (SceneManager.GetActiveScene().buildIndex + 2 == SceneManager.sceneCountInBuildSettings)
        {
            levelText.text = "Thanks for playing";
        }
        else
        {
            levelText.text = "Level " + (SceneManager.GetActiveScene().buildIndex).ToString();
        }
    }
}
