using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace _Project.Codebase.Core.Ball
{
    public class BallCompressionView : MonoBehaviour
    {
        [SerializeField] private Transform _meshParent;
        [SerializeField] private Vector3 _compressedScale = new Vector3(1, 1, 0.33f);

        //private PhysicsBody _physicsBody;
        private Vector3 _defaultScale;
        private CancellationTokenSource _cancellationTokenSource;

        // [Inject]
        // private void Construct(PhysicsBody physicsBody)
        // {
        //     _physicsBody = physicsBody;
        //     _physicsBody.ObjectHit += OnObjectHit;
        // }

        private void Awake()
        {
            _defaultScale = _meshParent.localScale;
        }

        private void OnDestroy()
        {
            AbortTask();
        }

        private void OnObjectHit(HitInfo _)
        {
            AbortTask();
            
            _cancellationTokenSource = new CancellationTokenSource();
            Task compressTask = CompressAsync(_cancellationTokenSource);
        }

        private async Task CompressAsync(CancellationTokenSource tokenSource)
        {
            float minScaleApproximately = 0.4f;
            float maxScaleApproximately = 0.98f;
            float lerpDelta = 0f;
            int waitTime = (int) (Time.fixedDeltaTime * 1000f);
            
            while (_meshParent.localScale.z > minScaleApproximately)
            {
                if (tokenSource.IsCancellationRequested)
                    return;
                
                _meshParent.localScale = Vector3.Lerp(_meshParent.localScale, _compressedScale, lerpDelta);
                lerpDelta += Time.fixedDeltaTime;
                await Task.Delay(waitTime);
            }

            lerpDelta = 0f;
            
            while (_meshParent.localScale.z < maxScaleApproximately)
            {
                if (tokenSource.IsCancellationRequested)
                    return;
                
                _meshParent.localScale = Vector3.Lerp(_meshParent.localScale, _defaultScale, lerpDelta);
                lerpDelta += Time.fixedDeltaTime;
                await Task.Delay(waitTime);
            }
            
            _meshParent.localScale = _defaultScale;
        }
        
        private void AbortTask()
        {
            if (_cancellationTokenSource != null)
                _cancellationTokenSource.Cancel();
        }
    }
}