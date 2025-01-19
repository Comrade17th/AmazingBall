using System;
using _Project.Codebase.Core.Entities;
using UniRx;
using Zenject;

namespace _Project.Codebase.Core.Wallet
{
    public class WalletViewModel : IDisposable
    {
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly WalletModel _walletModel;
        private readonly CoinCollector _coinCollector;

        private ReactiveProperty<int> _coins;
        private ReactiveProperty<string> _coinsLabel;
        
        public IReadOnlyReactiveProperty<int> Coins => _coins;
        public IReadOnlyReactiveProperty<string> CoinsLabel => _coinsLabel;

        [Inject]
        public WalletViewModel(WalletModel walletModel, CoinCollector coinCollector)
        {
            _walletModel = walletModel;
            _coinCollector = coinCollector;

            _coins = new ReactiveProperty<int>(_walletModel.Coins.Value);
            _coinsLabel = new ReactiveProperty<string>(_walletModel.CoinsLabel.Value);
            
            BindWalletModel();
            BindCoinCollector();
        }

        public void Dispose()
        {
            _compositeDisposable.Dispose();
            _compositeDisposable.Clear();
        }

        private void OnCoinCollected(Coin coin)
        {
            if (coin == null)
                throw new ArgumentNullException(nameof(coin));

            if (coin.Value > 0) 
                _walletModel.Coins.Value += coin.Value;
        }

        private void BindCoinCollector()
        {
            _coinCollector.CoinCollected
                .Subscribe(coin => OnCoinCollected(coin))
                .AddTo(_compositeDisposable);
        }

        private void BindWalletModel()
        {
            _walletModel.Coins
                .Subscribe(_ => _coins.Value = _walletModel.Coins.Value)
                .AddTo(_compositeDisposable);

            _walletModel.CoinsLabel
                .Subscribe(_ => _coinsLabel.Value = _walletModel.CoinsLabel.Value)
                .AddTo(_compositeDisposable);
        }
    }
}