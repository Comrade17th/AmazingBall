using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Project.Codebase.Core.Ball
{
    public class BallRotationView : MonoBehaviour, IBallRotationView
    {
        [SerializeField] private float _rotationCoefficient = 0.5f;
        
        public Transform Transform => transform;
        public float RotationCoefficient => _rotationCoefficient;
    }

    public interface IBallRotationView
    {
        Transform Transform { get; }
        float RotationCoefficient { get; }
    }
}