using UnityEngine;

namespace _Project.Codebase.Core.DeleteShipSubContainer
{
	using Zenject;
	using UnityEngine;

	public class Ship : MonoBehaviour
	{
		ShipHealthHandler _healthHandler;

		[Inject]
		public void Construct(ShipHealthHandler healthHandler)
		{
			_healthHandler = healthHandler;
		}

		public void TakeDamage(float damage)
		{
			_healthHandler.TakeDamage(damage);
		}

		public class Factoy : PlaceholderFactory<float, Ship>
		{
			
		}
	}
}