using UniRx;

namespace _Project.Codebase.Core.Wallet
{
    public class WalletModel
    {
        public ReactiveProperty<int> Coins { get; private set; }

        public WalletModel(int initialCoins = 0)
        {
            Coins = new ReactiveProperty<int>(initialCoins);
        }

        public void AddCoins(int amount = 1)
        {
            Coins.Value += amount;
        }
    }    
}

