using SunCo.Scripts.Managers;
using UnityEngine;
using SunCo.Scripts.Utils;

namespace SunCo.Scripts.UI
{
    public class SettingsMenu : MonoBehaviour
    {
        
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