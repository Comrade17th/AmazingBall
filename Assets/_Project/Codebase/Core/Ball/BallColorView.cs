using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Ball
{
    public class BallColorView : MonoBehaviour
    {
        [SerializeField] private float TimeMultiplier = 3f;
        [SerializeField] Color _compressedColor = Color.red;
        [SerializeField] MeshRenderer _meshRenderer;
        
        private Color _defaultColor;
        private PhysicsBody _physicsBody;
        private CancellationTokenSource _cancellationTokenSource;

        [Inject]
        private void Construct(PhysicsBody physicsBody)
        {
            _physicsBody = physicsBody;
            _physicsBody.ObjectHit += OnObjectHit;
        }

        private void OnDestroy()
        {
            _physicsBody.ObjectHit -= OnObjectHit;

            AbortTask();
        }

        private void Awake() => 
            _defaultColor = _meshRenderer.material.color;

        private void OnObjectHit(HitInfo _)
        {
            AbortTask();
            
            _cancellationTokenSource = new CancellationTokenSource();
            Task compressTask = CompressColorAsync(_cancellationTokenSource);
        }

        private async Task CompressColorAsync(CancellationTokenSource tokenSource)
        {
            int waitTime = (int) (Time.fixedDeltaTime * 1000f);
            float lerpDelta = 0f;

            while (_meshRenderer.sharedMaterial.color != _compressedColor)
            {
                if (tokenSource.IsCancellationRequested)
                    return;
                
                _meshRenderer.sharedMaterial.color = Color.Lerp(_defaultColor, _compressedColor, lerpDelta);
                lerpDelta += Time.deltaTime * TimeMultiplier;
                await Task.Delay(waitTime);
            }
            
            lerpDelta = 0f;
            
            while (_meshRenderer.sharedMaterial.color != _defaultColor)
            {
                if (tokenSource.IsCancellationRequested)
                    return;
                
                _meshRenderer.sharedMaterial.color = Color.Lerp(_compressedColor, _defaultColor, lerpDelta);
                lerpDelta += Time.deltaTime * TimeMultiplier;
                await Task.Delay(waitTime);
            }
        }

        private void AbortTask()
        {
            if (_cancellationTokenSource != null)
                _cancellationTokenSource.Cancel();
        }
    }
}