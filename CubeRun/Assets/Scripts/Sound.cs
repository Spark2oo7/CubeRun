using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    public string ImmortalName;
    public GameObject music;
    public AudioMixerGroup masterMixer;
    public AudioMixerGroup musicMixer;
    public AudioMixerGroup effectsMixer;
    void Start()
    {
        float volume = PlayerPrefs.GetFloat("EffectsVolume", -20);
        effectsMixer.audioMixer.SetFloat("EffectsVolume", volume);
        volume = PlayerPrefs.GetFloat("MusicVolume", -20);
        musicMixer.audioMixer.SetFloat("MusicVolume", volume);

        
        bool enabledmusic = PlayerPrefs.GetInt("EnabledMusic", 1) == 1;
        if (enabledmusic)
            masterMixer.audioMixer.SetFloat("MasterVolume", 0);
        else
            masterMixer.audioMixer.SetFloat("MasterVolume", -80);

        var immortalGO = GameObject.Find(ImmortalName);
        if (immortalGO == null)
        {
            immortalGO = (GameObject)Instantiate(music);
            immortalGO.name = ImmortalName;
        }
        DontDestroyOnLoad(immortalGO);
    }
}
