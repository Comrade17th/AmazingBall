using UnityEngine;

namespace _Project.Codebase.Core.Ball
{
	public class BallRotationViewModel : IBallRotationViewModel
	{
		private readonly IBallRotationView _rotationView;
		
		private float RotationCoefficient => _rotationView.RotationCoefficient;
		private Transform Transform => _rotationView.Transform;
		

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
			Debug.Log(velocity);
			Transform.rotation = Quaternion.LookRotation(new Vector3(
				velocity.x, 
				Transform.rotation.y,
				velocity.z));
		}
	}

	public interface IBallRotationViewModel
	{
		void Rotate(Vector3 velocity);
		void ChangeDirection(Vector3 velocity);
	}
}