using UniRx;

namespace _Project.Codebase.Core.Wallet
{
    public class WalletModel
    {
        public ReactiveProperty<int> Coins;
        public ReactiveProperty<string> CoinsLabel;

        public WalletModel(int initialCoins = 0, string label = "Coins:")
        {
            Coins = new ReactiveProperty<int>(initialCoins);
            CoinsLabel = new ReactiveProperty<string>(label);
        }
    }    
}

