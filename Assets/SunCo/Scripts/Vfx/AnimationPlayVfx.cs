using UnityEngine;

namespace SunCo.Scripts.Vfx
{
    public class AnimationPlayVfx : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] particleRoot;
        [SerializeField] private Robot robot;
        public void PlayParticles()
        {
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