using TMPro;
using UnityEngine;

namespace _Project.Codebase.Core.Ball.View
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