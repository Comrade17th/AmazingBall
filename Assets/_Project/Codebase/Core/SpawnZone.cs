using System;
using UnityEngine;

namespace _Project.Codebase.Core
{
	public class SpawnZone : MonoBehaviour
	{
		[SerializeField] private Color edgeColor = Color.red;
		[SerializeField] private Color equatorColor = Color.blue;
		[SerializeField] private Color floorColor = Color.red;

		[SerializeField] private bool _edgeEnabled = true;
		[SerializeField] private bool _equatorEnabled = true;
		[SerializeField] private bool _floorEnabled = true;
		
		private void OnDrawGizmos()
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
					transform.position.x,
					transform.position.y - transform.localScale.y / 2,
					transform.position.z), 
				new Vector3(
					transform.localScale.x,
					0,
					transform.localScale.z));
		}

		private void DrawEquator()
		{
			Gizmos.color = equatorColor;
			Gizmos.DrawWireCube(
				transform.position, 
				new Vector3(
					transform.localScale.x,
					0,
					transform.localScale.z));
		}

		private void DrawWireUpEdges()
		{
			Gizmos.color = edgeColor;
			Gizmos.DrawWireCube(transform.position, transform.localScale);
		}
	}
}