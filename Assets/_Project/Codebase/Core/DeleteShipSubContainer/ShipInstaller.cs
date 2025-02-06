using Zenject;

namespace _Project.Codebase.Core.DeleteShipSubContainer
{
	public class ShipInstaller : MonoInstaller
	{
		[Inject]
		private float _speed;
		
		public override void InstallBindings()
		{
			Container.BindInstance(_speed).WhenInjectedInto<ShipInputHandler>();
		}
	}
}