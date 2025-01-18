using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Ball
{
    public class BallHitEffectView : MonoBehaviour
    {
        [SerializeField] ParticleSystem _hitEffect;
        
        private PhysicsBody _physicsBody;

        [Inject]
        private void Construct(PhysicsBody physicsBody)
        {
            _physicsBody = physicsBody;
            _physicsBody.ObjectHit += OnObjectHit;
        }

        private void OnDestroy()
        {
            _physicsBody.ObjectHit -= OnObjectHit;
        }

        private void OnObjectHit(HitInfo hitInfo)
        {
            var hitEffect = Instantiate(_hitEffect, hitInfo.Point, Quaternion.identity);
        }
    }
}