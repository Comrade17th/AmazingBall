using _Project.Codebase.Core.Entities;

namespace _Project.Codebase.Core.Factories
{
    public class HitVFXFactory : VFXFactory<HitVFX>
    {
        public HitVFXFactory(HitVFX prefab, int size = 3) : base(prefab, size)
        {
        }
    }
}