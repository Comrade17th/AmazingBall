using UnityEngine;

namespace _Project.Codebase.Core.SpawnZones
{
	public class DirectionSpawnZone : MonoBehaviour, IDirectionSpawnZone
	{
		[SerializeField] private Color _color = Color.red;
		
		[Range(0, 10)] [SerializeField] private float _lineLenght = 1f;
		[Range(-1, 1)] [SerializeField] private float _directionX;
		[Range(-1, 1)] [SerializeField] private float _directionZ;
		
		private float _directionY = 0;

		public Vector3 Position => transform.position;
		public Vector3 Direction => new Vector3(_directionX, _directionY, _directionZ).normalized;

		private void OnDrawGizmos()
		{
			DrawArrow();
		}

		private void DrawArrow()
		{
			Gizmos.color = _color;
			Gizmos.DrawLine(transform.position, Position + Direction * _lineLenght);
			Gizmos.DrawSphere(Position, 0.25f);
			Gizmos.DrawSphere(Position + Direction * _lineLenght, 0.08f);
		}
	}

	public interface IDirectionSpawnZone : ISpawnZone
	{
		Vector3 Direction { get; }
	}

	public interface ISpawnZone
	{
		Vector3 Position { get; }
	}
}