using _Project.Codebase.Core.Spawnable;

namespace _Project.Codebase.Core.Factories
{
    public class CoinVFXFactory : VFXFactory<CoinVFX>
    {
        public CoinVFXFactory(CoinVFX prefab, int size) : base(prefab, size)
        {
        }
    }
}