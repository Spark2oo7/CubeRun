using UnityEngine;
using UnityEngine.UI;

public class TextTranslat : MonoBehaviour
{
    public string englishText = "error 725";
    public string russiaText = "error 694";

    void Start()
    {
        Text text = GetComponent<Text>();
        if (PlayerPrefs.GetString("Language", "English") == "English")
            text.text = englishText;
        else
            text.text = russiaText;
    }
}
