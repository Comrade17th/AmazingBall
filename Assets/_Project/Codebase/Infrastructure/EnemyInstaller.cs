using _Project.Codebase.Core.Attacker.EnemyAttacker;
using _Project.Codebase.Core.Enemies;
using _Project.Codebase.Core.Health.EnemyHealth;
using _Project.Codebase.Core.SpawnZones;
using ModestTree;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Infrastructure
{
	public class EnemyInstaller : MonoInstaller
	{
		[SerializeField] private EnemyView _enemyView;
		[SerializeField] private EnemyHealthBarView _enemyHealthBarView;
		[SerializeField] private EnemyHealthHitBox _enemyHealthHitBox;
		[SerializeField] private EnemyMoverView _enemyMoverView;
		
		public override void InstallBindings()
		{
			AssertNotNullFields();

			BindEnemyHealth();
			BindEnemyMVVM();
			BindEnemyAttacker();
			
			Container
				.Bind<IEnemyMoverView>()
				.To<EnemyMoverView>()
				.FromComponentInNewPrefab(_enemyMoverView)
				.AsSingle();

			Container
				.Bind<IEnemyMoverModel>()
				.To<EnemyMoverModel>()
				.AsSingle();
            
			Container
				.Bind<IEnemyMoverViewModel>()
				.To<EnemyMoverViewModel>()
				.AsSingle()
				.NonLazy();

			Container
				.Bind<IEnemyFactory>()
				.To<EnemyFactory>()
				.AsSingle();
		}

		private void AssertNotNullFields()
		{
			Assert.IsNotNull(_enemyView);
			Assert.IsNotNull(_enemyHealthBarView);
			Assert.IsNotNull(_enemyHealthHitBox);
			Assert.IsNotNull(_enemyMoverView);
		}

		private void BindEnemyHealth()
		{
			BindEnemyHealthModel();
			BindEnemyHealthBarView();
			BindEnemyHealthHitBox();
			BindEnemyHealthViewModel();
		}
		
		private void BindEnemyHealthViewModel()
		{
			Container
				.Bind<IEnemyHealthViewModel>()
				.To<EnemyHealthViewModel>()
				.AsSingle()
				.NonLazy();
		}

		private void BindEnemyHealthHitBox()
		{
			Container
				.Bind<IEnemyHealthHitBox>()
				.To<EnemyHealthHitBox>()
				.FromComponentInNewPrefab(_enemyHealthHitBox)
				.AsSingle();
		}

		private void BindEnemyHealthBarView()
		{
			Container
				.Bind<IEnemyHealthView>()
				.To<EnemyHealthBarView>()
				.FromComponentInNewPrefab(_enemyHealthBarView)
				.AsSingle();
		}

		private void BindEnemyHealthModel()
		{
			Container
				.Bind<IEnemyHealthModel>()
				.To<EnemyHealthModel>()
				.AsSingle();
		}
		
		private void BindEnemyMVVM()
		{
			BindEnemyView();
			BindEnemyViewModel();
		}
		
		private void BindEnemyViewModel()
		{
			Container
				.Bind<IEnemyViewModel>()
				.To<EnemyViewModel>()
				.AsSingle()
				.NonLazy();
		}

		private void BindEnemyView()
		{
			Container
				.Bind<IEnemyView>()
				.To<EnemyView>()
				.FromComponentInNewPrefab(_enemyView)
				.AsSingle();
		}
		
		private void BindEnemyAttacker()
		{
			BindEnemyAttackRool();
			BindEnemyAttackerModel();
			BindEnemyAttackeViewModel();
		}
		
		private void BindEnemyAttackeViewModel()
		{
			Container
				.Bind<IEnemyAttackerViewModel>()
				.To<EnemyAttackerViewModel>()
				.AsSingle()
				.NonLazy();
		}

		private void BindEnemyAttackerModel()
		{
			Container
				.Bind<IEnemyAttackerModel>()
				.To<EnemyAttackerModel>()
				.AsSingle();
		}

		private void BindEnemyAttackRool()
		{
			Container
				.Bind<IEnemyAttackRool>()
				.To<EnemyAttackRool>()
				.AsSingle();
		}
	}
}