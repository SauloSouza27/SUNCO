using UnityEngine;

namespace SunCo.Scripts.Vfx
{
    public class AnimationPlayVfx : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] particleRoot;
        [SerializeField] private Robot robot;
        [SerializeField] private AudioSource shootSound;

        public void PlayParticles()
        {
            shootSound.Play();

            foreach (var particle in particleRoot)
            {
                particle.Play(true);
            }
        }
        public void DoDamage()
        {
            if(robot != null)
            {
                robot.Action();
            }
        }
    }
}