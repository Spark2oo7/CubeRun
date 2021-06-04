using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public string ImmortalName;
    public GameObject music;
    void Start()
    {
        var immortalGO = GameObject.Find(ImmortalName);
        if (immortalGO == null)
        {
            immortalGO = (GameObject)Instantiate(music);
            immortalGO.name = ImmortalName;
        }
        DontDestroyOnLoad(immortalGO);
    }
}
