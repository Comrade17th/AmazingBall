using _Project.Codebase.Core.Factories;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Ball.View
{
    public class BallHitEffectView : IHitEffectView
    {
        private HitEffectFactory _factory;

        [Inject]
        public BallHitEffectView(HitEffectFactory factory) =>
            _factory = factory;

        public void CreateEffect(Vector3 at) =>
            _factory.Create(at);
    }

    public interface IHitEffectView : IEffectView
    {
        
    }

    public interface IEffectView
    {
        void CreateEffect(Vector3 at);
    }
}