using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.DeleteShipSubContainer
{
	public class ShipInputHandler : MonoBehaviour
	{
		
		private float _speed = 2;

		[Inject]
		private void Constuct(float speed)
		{
			_speed = speed;
		}

		public void Update()
		{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				transform.position += Vector3.forward * _speed * Time.deltaTime;
			}

			if (Input.GetKey(KeyCode.DownArrow))
			{
				transform.position -= Vector3.forward * _speed * Time.deltaTime;
			}
		}
	}
}