using UnityEngine;

namespace _Project.Codebase.Core.SpawnZones
{
	public class DirectionSpawnZone : MonoBehaviour, IDirectionSpawnZone
	{
		[SerializeField] private Color _color = Color.red;
		
		[Range(0.25f, 1.5f)] [SerializeField] private float _lineLenght = 1f;

		public Vector3 Position => transform.position;
		public Vector3 Direction => transform.forward;

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