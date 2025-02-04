using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Enemies
{
	public class EnemyViewModel : IEnemyViewModel
	{
		private readonly IEnemyView _view;

		public Transform Transform => _view.Transform;
		
		[Inject]
		public EnemyViewModel(IEnemyView view)
		{
			_view = view;
		}
	}

	public interface IEnemyViewModel
	{
		public Transform Transform { get; }
	}
}