using UnityEngine;

namespace _Project.Codebase.Core.Ball
{
	public struct ColorCompressSettings
	{
		public readonly Color CompressedColor;
		public readonly float TimeMultiplier;
		public readonly MeshRenderer MeshRenderer;
		public readonly Color DefaultColor;

		public ColorCompressSettings(
			MeshRenderer meshRenderer,
			Color defaultColor,
			Color compressedColor,
			float timeMultiplier)
		{
			MeshRenderer = meshRenderer;
			DefaultColor = defaultColor;
			CompressedColor = compressedColor;
			TimeMultiplier = timeMultiplier;
		}
	}
}