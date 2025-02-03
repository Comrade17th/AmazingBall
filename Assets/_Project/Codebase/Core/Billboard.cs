using System;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace _Project.Codebase.Core
{
	public class Billboard : MonoBehaviour
	{
		private Camera _camera;

		[Inject]
		private void Construct(Camera camera) =>
			_camera = camera ? camera : throw new ArgumentNullException(nameof(camera));

		private void Awake() =>
			Assert.IsNotNull(_camera);

		private void LateUpdate() =>
			transform.forward = _camera.transform.forward;
	}
}