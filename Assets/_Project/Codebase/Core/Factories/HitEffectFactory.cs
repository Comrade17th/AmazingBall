using System.Collections.Generic;
using _Project.Codebase.Core.Spawnable;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Factories
{
    public class HitEffectFactory : VFXFactory
    {
        [Inject]
        public HitEffectFactory(HitVFX prefab, int size = 3) : base(prefab, size)
        {
        }
    }
}