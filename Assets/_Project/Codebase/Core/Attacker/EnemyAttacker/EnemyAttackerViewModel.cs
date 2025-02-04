using System;
using _Project.Codebase.Core.Ball;
using _Project.Codebase.Core.Ball.View;
using _Project.Codebase.Core.Ball.ViewModel;
using _Project.Codebase.Core.Enemies;
using _Project.Codebase.Core.Health.BallHealth;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Attacker.EnemyAttacker
{
	public class EnemyAttackerViewModel : IEnemyAttackerViewModel, IDisposable
	{
		private readonly CompositeDisposable _compositeDisposable = new();
		private readonly IEnemyAttackerModel _attackerModel;
		private readonly IEnemyViewModel _enemyViewModel;
		private readonly IBallViewModel _ballViewModel;
		private readonly IEnemyAttackRool _enemyAttackRool;

		private ReactiveProperty<int> _damage = new();

		[Inject]
		public EnemyAttackerViewModel(
			IEnemyAttackerModel attackerModel,
			IEnemyViewModel enemyViewModel,
			IBallViewModel ballViewModel,
			IEnemyAttackRool enemyAttackRool)
		{
			_attackerModel = attackerModel ?? throw new ArgumentNullException(nameof(attackerModel));
			_enemyViewModel = enemyViewModel ?? throw new ArgumentNullException(nameof(enemyViewModel));
			_ballViewModel = ballViewModel ?? throw new ArgumentNullException(nameof(ballViewModel));
			_enemyAttackRool = enemyAttackRool ?? throw new ArgumentNullException(nameof(enemyAttackRool));

			Bind();
		}

		private void Bind()
		{
			_attackerModel.Damage
				.Subscribe(damage => _damage.Value = damage)
				.AddTo(_compositeDisposable);

			_enemyViewModel.ObjectHit += OnObjectHit;
		}

		private void OnObjectHit(Collision other)
		{
			if (other.gameObject.TryGetComponent(out IBallHealthHitBox ballHitBox))
			{
				if(_enemyAttackRool.CanAttack(_enemyViewModel.Transform, _ballViewModel))
					ballHitBox.TakeDamage(_damage.Value);
			}
		}

		public void Dispose()
		{
			_compositeDisposable?.Dispose();
		}
	}
}