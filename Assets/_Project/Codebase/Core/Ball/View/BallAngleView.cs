using TMPro;
using UnityEngine;

namespace _Project.Codebase.Core.Ball.View
{
	public class BallAngleView: MonoBehaviour, IBallAngleView
	{
		[SerializeField] private TextMeshProUGUI _textField;
		
		public void Redraw(string label, string angle)
		{
			_textField.text = $"{label} {angle}";
		}
	}

	public interface IBallAngleView
	{
		void Redraw(string label, string angle);
	}
}