using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace _Project.Codebase.Core.Ball
{
    public class CompressionView : MonoBehaviour
    {
        [SerializeField] private Transform _meshParent;
        [SerializeField] private Vector3 _compressedScale = new Vector3(1, 1, 0.33f);

        private PhysicsBody _physicsBody;
        private Vector3 _defaultScale;

        [Inject]
        private void Construct(PhysicsBody physicsBody)
        {
            _physicsBody = physicsBody;
            _physicsBody.ObjectHit += OnObjectHit;
        }

        private void Awake()
        {
            _defaultScale = _meshParent.localScale;
        }

    private void OnObjectHit(Vector3 point, Vector3 normal, Vector3 velocity)
        {
            Task compressTask = CompressAsync();
        }

        private async Task CompressAsync()
        {
            float minScaleApproximately = 0.4f;
            float maxScaleApproximately = 0.98f;
            float lerpDelta = 0.2f;
            int waitTime = (int) (Time.deltaTime * 1000f);
            
            Debug.Log($"scale {_meshParent.localScale}");
            
            while (_meshParent.localScale.z > minScaleApproximately)
            {
                _meshParent.localScale = Vector3.Lerp(_meshParent.localScale, _compressedScale, lerpDelta);
                await Task.Delay(waitTime);
            }
            
            while (_meshParent.localScale.z < maxScaleApproximately)
            {
                _meshParent.localScale = Vector3.Lerp(_meshParent.localScale, _defaultScale, lerpDelta);
                await Task.Delay(waitTime);
            }
            
            

            _meshParent.localScale = _defaultScale;
        }
    }
}