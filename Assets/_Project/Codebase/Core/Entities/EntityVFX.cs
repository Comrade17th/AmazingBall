using UnityEngine;

namespace _Project.Codebase.Core.Entities
{
    public class EntityVFX : MonoBehaviour
    {
        [SerializeField] protected ParticleSystem ParticleSystem;

        public void Restart()
        {
            ParticleSystem.Stop();
            ParticleSystem.Play();
        }
    }
}