using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Ball
{
	public class BallColorViewModel : IBallColorViewModel, IDisposable
	{
		private readonly IBallColorView _ballColorView;
		private readonly MeshRenderer _meshRenderer;
		private readonly float _timeMultiplier;
		private readonly Color _compressedColor;
		private readonly Color _defaultColor;
		
		private CancellationTokenSource _cancellationTokenSource;

		[Inject]
		public BallColorViewModel(IBallColorView ballColorView)
		{
			_ballColorView = ballColorView;
			_meshRenderer = ballColorView.Settings.MeshRenderer;
			_timeMultiplier = ballColorView.Settings.TimeMultiplier;
			_compressedColor = ballColorView.Settings.CompressedColor;
			_defaultColor = ballColorView.Settings.DefaultColor;
		}
		
		public void CompressAsync()
		{
			AbortTask();
            
			_cancellationTokenSource = new CancellationTokenSource();
			Task compressTask = CompressColorAsync(_cancellationTokenSource);
		}
		
		public void Dispose()
		{
			AbortTask();
			_cancellationTokenSource?.Dispose();
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
				lerpDelta += Time.deltaTime * _timeMultiplier;
				await Task.Delay(waitTime);
			}
            
			lerpDelta = 0f;
            
			while (_meshRenderer.sharedMaterial.color != _defaultColor)
			{
				if (tokenSource.IsCancellationRequested)
					return;
                
				_meshRenderer.sharedMaterial.color = Color.Lerp(_compressedColor, _defaultColor, lerpDelta);
				lerpDelta += Time.deltaTime * _timeMultiplier;
				await Task.Delay(waitTime);
			}
		}
		
		private void AbortTask()
		{
			if (_cancellationTokenSource != null)
				_cancellationTokenSource.Cancel();
		}
	}

	public interface IBallColorViewModel
	{
		void CompressAsync(){}
	}
}