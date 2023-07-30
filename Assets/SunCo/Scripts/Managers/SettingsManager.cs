using SunCo.Scripts.Utils;
using UnityEngine;
using UnityEngine.Audio;

namespace SunCo.Scripts.Managers
{
    public class SettingsManager : PersistentSingleton<SettingsManager>
    {
        [SerializeField] private AudioMixer audioMixer;
        public AudioMixer Mixer => audioMixer;
    }
}