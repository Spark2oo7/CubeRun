using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLanguage : MonoBehaviour
{
    public GameObject selectLanguage;

    void Start()
    {
        if (PlayerPrefs.GetString("Language", "nul") == "nul")
        {
            selectLanguage.SetActive(true);
        }
    }

    public void SetLanguage(string language)
    {
        PlayerPrefs.SetString("Language", language);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}