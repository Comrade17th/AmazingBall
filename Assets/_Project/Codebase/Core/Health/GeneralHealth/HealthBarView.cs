using UnityEngine;
using UnityEngine.UI;

namespace _Project.Codebase.Core.Health.GeneralHealth
{
	public class HealthBarView : HealthView, IHealthBarView
	{
		[SerializeField] private Image _fillArea;

		public override void Redraw(string label, int current, int max)
		{
			float fillPercent = current / (float) max;
			_fillArea.fillAmount = fillPercent;
			base.Redraw(label, current, max);
		}
	}

	public interface IHealthBarView : IHealthView
	{
	}
}