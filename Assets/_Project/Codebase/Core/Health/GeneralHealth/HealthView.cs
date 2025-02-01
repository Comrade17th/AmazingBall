using TMPro;
using UnityEngine;

namespace _Project.Codebase.Core.Health.GeneralHealth
{
	public class HealthView: MonoBehaviour, IHealthView
	{
		[SerializeField] protected TextMeshProUGUI _textField;
		
		public void Redraw(string label, string current, string max)
		{
			_textField.text = $"{label} {current}/{max}";
		}
	}

	public interface IHealthView
	{
		void Redraw(string label, string current, string max);
	}
}