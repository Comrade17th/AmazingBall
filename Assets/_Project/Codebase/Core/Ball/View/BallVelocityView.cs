using TMPro;
using UnityEngine;

namespace _Project.Codebase.Core.Ball.View
{
	public class BallVelocityView : MonoBehaviour, IBallVelocityView
	{
		[SerializeField] private TextMeshProUGUI _textField; 
		
		public void Redraw(string label, float linearVelocity)
		{
			_textField.text = $"{label} {linearVelocity}";
		}
	}

	public interface IBallVelocityView
	{
		void Redraw(string label, float linearVelocity);
	}
}