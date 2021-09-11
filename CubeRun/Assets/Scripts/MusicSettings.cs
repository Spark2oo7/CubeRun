using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{
    public Slider musicSlider;
    public Slider effectsSlider;
    public Toggle enabledMusic;
    public AudioMixerGroup master;
    public AudioMixerGroup music;
    public AudioMixerGroup effects;
    public AudioSource end;
    public float timeToPlayEnd;
    public float timeToEnd = float.NaN;
    public float lastEffectsVolume;
    public float accuracy;

    private void Start()
    {
        enabledMusic.isOn = PlayerPrefs.GetInt("EnabledMusic", 1) == 1;
        musicSlider.value =  -Mathf.Sqrt(-PlayerPrefs.GetFloat("MusicVolume", -20));
        effectsSlider.value =  -Mathf.Sqrt(-PlayerPrefs.GetFloat("EffectsVolume", -20));
    }
    
    void Update()
    {
        if (timeToEnd != float.NaN)
        {
            timeToEnd -= Time.deltaTime;
            if (timeToEnd < 0)
            {
                end.Play();
                timeToEnd = float.NaN;
            }
        }
    }

    public void ChengeMusicVolume(float volume)
    {
        float newVolume = -volume*volume;
        music.audioMixer.SetFloat("MusicVolume", newVolume);
        PlayerPrefs.SetFloat("MusicVolume", newVolume);
    }

    public void ChengeEffectsVolume(float volume)
    {
        float newVolume = -volume*volume;
        if (PlayerPrefs.GetFloat("EffectsVolume", -20) != newVolume)
        {
            effects.audioMixer.SetFloat("EffectsVolume", newVolume);
            PlayerPrefs.SetFloat("EffectsVolume", newVolume);
            if (Mathf.Abs(volume - lastEffectsVolume) > accuracy)
            {
                lastEffectsVolume = volume;
                timeToEnd = timeToPlayEnd;
            }
        }
    }

    public void ToggleMusic(bool enabled)
    {
        if (enabled)
        {
            PlayerPrefs.SetInt("EnabledMusic", 1);
            master.audioMixer.SetFloat("MasterVolume", 0);
        }
        else
        {
            PlayerPrefs.SetInt("EnabledMusic", 0);
            master.audioMixer.SetFloat("MasterVolume", -80);
        }
    }
}
