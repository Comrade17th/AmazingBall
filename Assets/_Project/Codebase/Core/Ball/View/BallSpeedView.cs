using TMPro;
using UnityEngine;

namespace _Project.Codebase.Core.Ball.View
{
	public class BallSpeedView : MonoBehaviour, IBallSpeedView
	{
		[SerializeField] private TextMeshProUGUI _textField; 
		
		public void Redraw(string label, string linearVelocity)
		{
			_textField.text = $"{label} {linearVelocity}";
		}
	}

	public interface IBallSpeedView
	{
		void Redraw(string label, string linearVelocity);
	}
}