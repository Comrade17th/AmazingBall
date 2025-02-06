using UnityEngine;
using Zenject;
namespace _Project.Codebase.Core.DeleteShipSubContainer

{
	public class GameRunner : ITickable
	{
		readonly Ship.Factoy _shipFactory;

		private Vector3 lastShipPosition;

		public GameRunner(Ship.Factoy factory)
		{
			_shipFactory = factory;
		}

		public void Tick()
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				var ship = _shipFactory.Create(Random.Range(2, 20));
				ship.transform.position = lastShipPosition;
				lastShipPosition += Vector3.forward * 2;
			}
		}
	}
}