using System;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

namespace _Project.Codebase.Core.Health.GeneralHealth
{
	public class HealthView: MonoBehaviour, IHealthView
	{
		[SerializeField] protected TextMeshProUGUI TextField;

		private void Awake() =>
			Assert.IsNotNull(TextField);

		public virtual void Redraw(string label, int current, int max) =>
			TextField.text = $"{label} {current}/{max}";
	}

	public interface IHealthView
	{
		void Redraw(string label, int current, int max);
	}
}