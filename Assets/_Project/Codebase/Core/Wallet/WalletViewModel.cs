using UniRx;
using Zenject;

namespace _Project.Codebase.Core.Wallet
{
    public class WalletViewModel
    {
        private CompositeDisposable _compositeDisposable = new CompositeDisposable();
        private WalletModel _walletModel;

        public ReactiveProperty<int> Coins { get; private set; }

        [Inject]
        public WalletViewModel(WalletModel walletModel)
        {
            _walletModel = walletModel;

            Coins = new ReactiveProperty<int>(_walletModel.Coins.Value);
            
            _walletModel.Coins
                .Subscribe(_ => Coins.Value = _walletModel.Coins.Value)
                .AddTo(_compositeDisposable);
        }
    }
}