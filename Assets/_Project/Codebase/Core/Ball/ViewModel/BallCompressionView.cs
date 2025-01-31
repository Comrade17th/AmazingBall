using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Ball
{
	public class BallCompressionView : MonoBehaviour, IBallCompressionView
	{
		[SerializeField] private Transform _meshParent;
		[SerializeField] private Vector3 _compressedScale = new Vector3(1, 1, 0.33f);

		public Transform MeshPrent => _meshParent;
		public Vector3 CompressedScale => _compressedScale;
		public Vector3 DefaultScale => _meshParent.localScale;

		
	}

	public interface IBallCompressionView
	{
		Transform MeshPrent { get; }
		Vector3 CompressedScale { get; }
		Vector3 DefaultScale { get; }
	}
}