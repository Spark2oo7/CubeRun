using UnityEngine;
using UnityEngine.SceneManagement;

public class LanguageSettings : MonoBehaviour
{
    public GameObject selectRussia;
    public GameObject selectEnglish;

    void Start()
    {
        if (PlayerPrefs.GetString("Language", "English") == "English")
            selectEnglish.SetActive(true);
        else
            selectRussia.SetActive(true);
    }

    public void SetLanguage(string language)
    {
        PlayerPrefs.SetString("Language", language);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
