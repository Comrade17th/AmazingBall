using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Ball
{
    public class BallCompressionViewModel : IBallCompressionViewModel, IDisposable
    {
        private readonly IBallCompressionView _ballCompressionView;
        private readonly Vector3 _defaultScale;
        private CancellationTokenSource _cancellationTokenSource;
        
        private Transform MeshParent => _ballCompressionView.MeshPrent;
        private Vector3 CompressedScale => _ballCompressionView.CompressedScale;
        

        [Inject]
        public BallCompressionViewModel(IBallCompressionView ballCompressionView)
        {
            _ballCompressionView = ballCompressionView;
            _defaultScale = _ballCompressionView.DefaultScale;
        }
        
        public void CompressAsync()
        {
            AbortTask();
            
            _cancellationTokenSource = new CancellationTokenSource();
            Task compressTask = CompressAsync(_cancellationTokenSource);
        }
        
        public void Dispose()
        {
            AbortTask();
            _cancellationTokenSource?.Dispose();
        }

        private async Task CompressAsync(CancellationTokenSource tokenSource)
        {
            float minScaleApproximately = 0.4f;
            float maxScaleApproximately = 0.98f;
            float lerpDelta = 0f;
            int waitTime = (int) (Time.fixedDeltaTime * 1000f);
            
            while (MeshParent.localScale.z > minScaleApproximately)
            {
                if (tokenSource.IsCancellationRequested)
                    return;
                
                MeshParent.localScale = Vector3.Lerp(MeshParent.localScale, CompressedScale, lerpDelta);
                lerpDelta += Time.fixedDeltaTime;
                await Task.Delay(waitTime);
            }

            lerpDelta = 0f;
            
            while (MeshParent.localScale.z < maxScaleApproximately)
            {
                if (tokenSource.IsCancellationRequested)
                    return;
                
                MeshParent.localScale = Vector3.Lerp(MeshParent.localScale, _defaultScale, lerpDelta);
                lerpDelta += Time.fixedDeltaTime;
                await Task.Delay(waitTime);
            }
            
            MeshParent.localScale = _defaultScale;
        }
        
        private void AbortTask()
        {
            if (_cancellationTokenSource != null)
                _cancellationTokenSource.Cancel();
        }
    }
    
    public interface IBallCompressionViewModel
    {
        void CompressAsync();
    }
}