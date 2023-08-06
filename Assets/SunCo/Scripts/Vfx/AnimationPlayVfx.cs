using System.Collections;
using UnityEngine;

namespace SunCo.Scripts.Vfx
{
    public class AnimationPlayVfx : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] particleRoot;
        [SerializeField] private AudioSource shootSound;
        [SerializeField] private Robot robot;

        public void PlayParticles()
        {
            shootSound.Play();
            foreach (var particle in particleRoot)
            {
                particle.Play(true);
            }
        }
        public void PlayProjectiles()
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