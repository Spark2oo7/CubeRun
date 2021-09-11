using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public Text levelText;

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelNumber()
    {
        if (SceneManager.GetActiveScene().buildIndex + 3 == SceneManager.sceneCountInBuildSettings)
        {
            if (PlayerPrefs.GetString("Language", "English") == "English")
                levelText.text = "Thanks for playing";
            else
                levelText.text = "Спасибо за игру";
        }
        else
        {
            if (PlayerPrefs.GetString("Language", "English") == "English")
                levelText.text = "Level " + (SceneManager.GetActiveScene().buildIndex).ToString();
            else
                levelText.text = "Уровень " + (SceneManager.GetActiveScene().buildIndex).ToString();
        }
    }
}
