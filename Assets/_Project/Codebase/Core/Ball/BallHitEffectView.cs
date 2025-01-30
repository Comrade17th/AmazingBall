using _Project.Codebase.Core.Factories;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Ball
{
    public class BallHitEffectView : MonoBehaviour, IHitEffectView
    {
        private HitEffectFactory _factory;

        [Inject]
        private void Construct(HitEffectFactory factory)
        {
            _factory = factory;
        }

        public void CreateEffect(Vector3 at)
        {
            _factory.Create(at);
        }
    }

    public interface IHitEffectView : IEffectView
    {
        
    }

    public interface IEffectView
    {
        void CreateEffect(Vector3 at);
    }
}