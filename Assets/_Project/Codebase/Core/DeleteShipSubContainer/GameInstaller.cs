using UnityEngine;

namespace _Project.Codebase.Core.DeleteShipSubContainer
{
	using Zenject;

	public class GameInstaller : MonoInstaller
	{
		[SerializeField] private GameObject shipPrefab;
		
		public override void InstallBindings()
		{
			Container.BindInterfacesTo<GameRunner>().AsSingle();
			Container.BindFactory<float, Ship, Ship.Factoy>().FromSubContainerResolve().ByNewContextPrefab<ShipInstaller>(shipPrefab);
		}
	}
}