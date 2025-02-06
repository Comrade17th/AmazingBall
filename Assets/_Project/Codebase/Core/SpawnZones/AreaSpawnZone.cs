using UnityEngine;

namespace _Project.Codebase.Core.SpawnZones
{
	public class AreaSpawnZone : MonoBehaviour, IAreaSpawnZone
	{
		[SerializeField] private Color edgeColor = Color.red;
		[SerializeField] private Color equatorColor = Color.blue;
		[SerializeField] private Color floorColor = Color.red;

		[SerializeField] private bool _edgeEnabled = true;
		[SerializeField] private bool _equatorEnabled = true;
		[SerializeField] private bool _floorEnabled = true;

		public Transform Transform => transform;
		public Vector3 Position => transform.position;
		public Vector3 EquatorSize => new Vector3(transform.localScale.x,
			0,
			transform.localScale.z);
		
		private void OnDrawGizmos()
		{
			DrawFrame();
		}

		private void DrawFrame()
		{
			if(_edgeEnabled)
				DrawWireUpEdges();

			if (_equatorEnabled)
				DrawEquator();
			
			if(_floorEnabled)
				DrawFloor();
		}

		private void DrawFloor()
		{
			Gizmos.color = floorColor;
			Gizmos.DrawCube(
				new Vector3(
					Position.x,
					Position.y - transform.localScale.y / 2,
					Position.z), 
				EquatorSize);
		}

		private void DrawEquator()
		{
			Gizmos.color = equatorColor;
			Gizmos.DrawWireCube(
				transform.position, 
				EquatorSize);
		}

		private void DrawWireUpEdges()
		{
			Gizmos.color = edgeColor;
			Gizmos.DrawWireCube(transform.position, transform.localScale);
		}
	}

	public interface IAreaSpawnZone : ISpawnZone
	{
		Vector3 EquatorSize { get; }
	}
}