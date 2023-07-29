using UnityEngine;

namespace SunCo.Scripts.Utils
{
    public static class Conversions
    {
        /// <summary>
        ///     Better calculation of Logarithmic values
        /// </summary>
        /// <param name="volume">Value between 0 and 1.</param>
        /// <returns>Returns a value between 0 and -80 to be used as volume of AudioMixer</returns>
        public static float LogarithmicDbTransform(float volume)
        {
            volume = Mathf.Clamp01(volume);
            volume = (Mathf.Log(89 * volume + 1) / Mathf.Log(90)) * 80;
            float dbTransform = volume - 80;
            return dbTransform;
        }
    }
}