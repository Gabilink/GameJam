using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    #region Singleton
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    [SerializeField] private AudioMixer masterAudioMixer;

    #region Sliders
    public void SetMasterVolume(float volume)
    {
        masterAudioMixer.SetFloat("Volumen", volume);
    }
    public void SetMusicVolume(float volume)
    {
        masterAudioMixer.SetFloat("MusicaVol", volume);
    }
    public void SetSFXVolume(float volume)
    {
        masterAudioMixer.SetFloat("SFXVol", volume);
    }
    #endregion
}