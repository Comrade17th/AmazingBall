using UnityEngine;

namespace _Project.Codebase.Core.Spawnable
{
    public class EffectBase : MonoBehaviour
    {
        [SerializeField] protected ParticleSystem ParticleSystem;

        public void Restart()
        {
            ParticleSystem.Stop();
            ParticleSystem.Play();
        }
    }
}