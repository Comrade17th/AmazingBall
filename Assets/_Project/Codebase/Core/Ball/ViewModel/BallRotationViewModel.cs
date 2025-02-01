using _Project.Codebase.Core.Ball.View;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Ball.ViewModel
{
	public class BallRotationViewModel : IBallRotationViewModel
	{
		private readonly IBallRotationView _rotationView;
		
		private float RotationCoefficient => _rotationView.RotationCoefficient;
		private Transform Transform => _rotationView.Transform;
		private ReactiveProperty<Quaternion> _rotation = new();
		
		public IReadOnlyReactiveProperty<Quaternion> Rotation => _rotation;
		
		[Inject]
		public BallRotationViewModel(IBallRotationView rotationView)
		{
			_rotationView = rotationView;
		}

		public void Rotate(Vector3 velocity)
		{
			velocity *= RotationCoefficient;
            
			float velocityX = Mathf.Abs(velocity.x);
			float velocityZ = Mathf.Abs(velocity.z);
			Transform.Rotate(
				new Vector3(velocityX > velocityZ ? velocityX : velocityZ, 
					0,
					0),
				Space.Self);
		}

		public void ChangeDirection(Vector3 velocity)
		{
			//if(velocity.y == 0f) 
			Transform.rotation = Quaternion.LookRotation(new Vector3(
				velocity.x, 
				Transform.rotation.y,
				velocity.z));

			_rotation.Value = _rotationView.Transform.rotation;
		}
	}

	public interface IBallRotationViewModel
	{
		void Rotate(Vector3 velocity);
		void ChangeDirection(Vector3 velocity);

		IReadOnlyReactiveProperty<Quaternion> Rotation { get; }
	}
}