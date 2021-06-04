using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Attempts : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "attempts: " + PlayerPrefs.GetInt(SceneManager.GetActiveScene().name, 0).ToString();
    }
}
