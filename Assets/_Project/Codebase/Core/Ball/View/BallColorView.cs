using UnityEngine;

namespace _Project.Codebase.Core.Ball.View
{
    [RequireComponent(typeof(MeshRenderer))]
    public class BallColorView : MonoBehaviour, IBallColorView
    {
        [SerializeField] private float TimeMultiplier = 20f;
        [SerializeField] private Color _compressedColor = Color.red;
        [SerializeField] private MeshRenderer _meshRenderer;
        private Color DefaultColor => _meshRenderer.material.color;

        public ColorCompressSettings Settings => 
            new(_meshRenderer, 
            DefaultColor, 
            _compressedColor, 
            TimeMultiplier);
    }

    public interface IBallColorView
    {
        ColorCompressSettings Settings { get; }
    }
}