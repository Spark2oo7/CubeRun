using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Attempts : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetString("Language", "English") == "English")
            GetComponent<Text>().text = "Attempts: " + PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0).ToString();
        else
            GetComponent<Text>().text = "Попытки: " + PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0).ToString();
    }
}
