using UniRx;

namespace _Project.Codebase.Core.Wallet
{
    public class WalletModel
    {
        public ReactiveProperty<int> Coins = new();
        public ReactiveProperty<string> CoinsLabel = new();

        public WalletModel(int initialCoins = 0, string label = "Coins:")
        {
            Coins.Value = initialCoins;
            CoinsLabel.Value = label;
        }
    }    
}

