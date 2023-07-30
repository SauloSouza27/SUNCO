using UnityEngine;

namespace SunCo.Scripts.Vfx
{
    public class AnimationPlayVfx : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] particleRoot;

        public void PlayParticles()
        {
            foreach (var particle in particleRoot)
            {
                particle.Play(true);
            }
        }
        
    }
}