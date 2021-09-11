using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EnableMusic : MonoBehaviour
{
    public AudioMixerGroup mixer;
    public Sprite enabledMusic;
    public Sprite desabledMusic;
    public Image image;
    
    void Start()
    {
        UpdateMusic();
    }

    public void SwitchMusic()
    {
        bool music = PlayerPrefs.GetInt("EnabledMusic", 1) == 1;
        if (music)
            PlayerPrefs.SetInt("EnabledMusic", 0);
        else
            PlayerPrefs.SetInt("EnabledMusic", 1);
        UpdateMusic();
    }

    private void UpdateMusic()
    {
        bool music = PlayerPrefs.GetInt("EnabledMusic", 1) == 1;
        if (music)
        {
            mixer.audioMixer.SetFloat("MasterVolume", 0);
            image.sprite = enabledMusic;
        }
        else
        {
            mixer.audioMixer.SetFloat("MasterVolume", -80);
            image.sprite = desabledMusic;
        }
    }
}
