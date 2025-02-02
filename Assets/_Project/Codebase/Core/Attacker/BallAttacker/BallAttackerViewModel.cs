using System;
using _Project.Codebase.Core.Ball.View;
using _Project.Codebase.Core.Ball.ViewModel;
using _Project.Codebase.Core.Health.EnemyHealth;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Attacker.BallAttacker
{
	public class BallAttackerViewModel: IBallAttackerViewModel, IDisposable
	{
		private readonly CompositeDisposable _compositeDisposable = new();
		private readonly IBallViewModel _ballViewModel;
		private readonly IBallAttackRool _attackRool;
		private readonly IBallAttackerModel _ballAttackerModel;

		private ReactiveProperty<int> Damage = new();
		private ReactiveProperty<float> AngleRange = new();

		[Inject]
		public BallAttackerViewModel(
			IBallViewModel ballViewModel,
			IBallAttackRool attackRool,
			IBallAttackerModel ballAttackerModel)
		{
			_ballViewModel = ballViewModel;
			_attackRool = attackRool;
			_ballAttackerModel = ballAttackerModel;
			Bind();
		}

		private void Bind()
		{
			_ballAttackerModel.Damage
				.Subscribe(damage => Damage.Value = damage)
				.AddTo(_compositeDisposable);

			_ballAttackerModel.AngleRange
				.Subscribe(angle => AngleRange.Value = angle)
				.AddTo(_compositeDisposable);
			
			_ballViewModel.ObjectHit += OnObjectHit;
		}

		public void Dispose()
		{
			_compositeDisposable?.Dispose();
			_ballViewModel.ObjectHit -= OnObjectHit;
		}

		private void OnObjectHit(HitInfo hitInfo)
		{
			Collider collider = hitInfo.ContactPoint.otherCollider;

			if (collider.TryGetComponent(out IEnemyHealthHitBox enemyHitBox))
			{
				if(_attackRool.CanAttack(hitInfo, AngleRange.Value))
					enemyHitBox.TakeDamage(Damage.Value);
			}
		}
	}

	public interface IBallAttackerViewModel
	{
	}
}