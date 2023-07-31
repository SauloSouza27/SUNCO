using System;
using SunCo.Scripts.Utils;
using UnityEngine;
using UnityEngine.Audio;

namespace SunCo.Scripts.Managers
{
    public class SettingsManager : PersistentSingleton<SettingsManager>
    {
        [SerializeField] private AudioMixer audioMixer;
        public AudioMixer Mixer => audioMixer;

        public void SaveVolume()
        {
            audioMixer.GetFloat("MasterVolume", out float masterVolume);
            PlayerPrefs.SetFloat("MasterVolume", masterVolume);
            
            audioMixer.GetFloat("MusicVolume", out float musicVolume);
            PlayerPrefs.SetFloat("MusicVolume", musicVolume);
            
            audioMixer.GetFloat("SfxVolume", out float sfxVolume);
            PlayerPrefs.SetFloat("SfxVolume", sfxVolume);
        }

        private void Start()
        {
            LoadVolume();
        }

        public void LoadVolume()
        {
            if (PlayerPrefs.HasKey("MasterVolume"))
            {
                float masterVolume = PlayerPrefs.GetFloat("MasterVolume");
                audioMixer.SetFloat("MasterVolume", masterVolume);
            }
            else
            {
                audioMixer.SetFloat("MasterVolume", 1);
            }
            
            
            if (PlayerPrefs.HasKey("MusicVolume"))
            {
                float musicVolume = PlayerPrefs.GetFloat("MusicVolume");
                audioMixer.SetFloat("MusicVolume", musicVolume);
            }
            else
            {
                audioMixer.SetFloat("MusicVolume", 0.8f);
            }
            
            if (PlayerPrefs.HasKey("SfxVolume"))
            {
                float sfxVolume = PlayerPrefs.GetFloat("SfxVolume");
                audioMixer.SetFloat("SfxVolume", sfxVolume);
            }
            else
            {
                audioMixer.SetFloat("SfxVolume", 0.8f);
            }
        }
    }
}