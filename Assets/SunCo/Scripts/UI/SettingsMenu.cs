using System;
using SunCo.Scripts.Managers;
using UnityEngine;
using SunCo.Scripts.Utils;
using UnityEngine.UI;

namespace SunCo.Scripts.UI
{
    public class SettingsMenu : MonoBehaviour
    {
        [SerializeField] private Slider masterSlider;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider sfxSlider;
        
        private void OnEnable()
        {
            SettingsManager.instance.Mixer.GetFloat("MasterVolume", out float masterVolume);
            // Debug.Log(masterVolume + " " +  (masterVolume+80) / 80);
            masterVolume = Mathf.Lerp(0, 1, (masterVolume + 80) / 80);
            // Debug.Log(masterVolume);
            masterSlider.value =  masterVolume;
            
            SettingsManager.instance.Mixer.GetFloat("MusicVolume", out float musicVolume);
            musicVolume = Mathf.Lerp(0, 1, (musicVolume + 80) / 80);
            musicSlider.value =  musicVolume;
            
            SettingsManager.instance.Mixer.GetFloat("SfxVolume", out float sfxVolume);
            sfxVolume = Mathf.Lerp(0, 1, (sfxVolume + 80) / 80);
            sfxSlider.value =  sfxVolume;
        }

        public void UpdateMasterVolume(float newVolume)
        {
            SettingsManager.instance.Mixer.SetFloat("MasterVolume", Conversions.LogarithmicDbTransform(newVolume));
        }
        public void UpdateMusicVolume(float newVolume)
        {
            SettingsManager.instance.Mixer.SetFloat("MusicVolume", Conversions.LogarithmicDbTransform(newVolume));
        }
        public void UpdateSfxVolume(float newVolume)
        {
            SettingsManager.instance.Mixer.SetFloat("SfxVolume", Conversions.LogarithmicDbTransform(newVolume));
        }
    }
}