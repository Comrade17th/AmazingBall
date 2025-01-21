using _Project.Codebase.Core.Entities;
using _Project.Codebase.Core.Factories;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Ball
{
    public class BallHitEffectView : MonoBehaviour
    {
        [SerializeField] ParticleSystem _hitEffect;
        
        private VFXFactory<HitVFX> _factory;
        private PhysicsBody _physicsBody;

        [Inject]
        private void Construct(PhysicsBody physicsBody, VFXFactory<HitVFX> factory)
        {
            _factory = factory;
            _physicsBody = physicsBody;
            _physicsBody.ObjectHit += OnObjectHit;
        }

        private void OnDestroy()
        {
            _physicsBody.ObjectHit -= OnObjectHit;
        }

        private void OnObjectHit(HitInfo hitInfo)
        {
            _factory.Create(hitInfo.Point);
            //var hitEffect = Instantiate(_hitEffect, hitInfo.Point, Quaternion.identity);
        }
    }
}