using _Project.Codebase.Core.Health.BallHealth;
using _Project.Codebase.Core.Health.GeneralHealth;
using UnityEditor;
using UnityEngine;

namespace _Project.Codebase.CustomEditor
{
	[UnityEditor.CustomEditor(typeof(BallHealthHitBox))]
	public class HealthHitBoxHelper : Editor
	{
		private const string TakeDamageButton = "TakeDamage";

		[SerializeField] private int _editorDamage= 1;
		
		public override void OnInspectorGUI()
		{
			HealthHitBox hitBox = (HealthHitBox) target;
			_editorDamage = EditorGUILayout.IntField("Damage", _editorDamage);
			
			if (GUILayout.Button(TakeDamageButton))
			{
				hitBox.TakeDamage(_editorDamage);
			}
		}
	}
}