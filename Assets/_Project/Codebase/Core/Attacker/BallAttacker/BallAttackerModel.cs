using _Project.Codebase.Core.Attacker.GeneralAttacker;
using UniRx;
using UnityEngine;

namespace _Project.Codebase.Core.Attacker.BallAttacker
{
	public class BallAttackerModel: AttackerModel, IBallAttackerModel
	{
		public ReactiveProperty<float> AngleRange { get; set; }

		public BallAttackerModel(int damage = 1, int angleRange = 10) : base(damage)
		{
			AngleRange = new(angleRange);
		}
	}
}