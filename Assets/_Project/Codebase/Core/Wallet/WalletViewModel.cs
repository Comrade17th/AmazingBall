using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.Codebase.Core.Wallet
{
    public class WalletViewModel : IDisposable
    {
        private readonly CompositeDisposable _compositeDisposable = new();
        private readonly WalletModel _walletModel;
        private readonly IWalletView _walletView;
        private readonly CoinCollector _coinCollector;

        private ReactiveProperty<int> _coins;
        private ReactiveProperty<string> _coinsLabel;

        [Inject]
        public WalletViewModel(
            WalletModel walletModel,
            CoinCollector coinCollector,
            IWalletView walletView)
        {
            _walletModel = walletModel;
            _coinCollector = coinCollector;
            _walletView = walletView;

            _coins = new ReactiveProperty<int>(_walletModel.Coins.Value);
            _coinsLabel = new ReactiveProperty<string>(_walletModel.CoinsLabel.Value);
            
            BindWalletModel();
            BindCoinCollector();
            BindWalletView();
        }

        public void Dispose()
        {
            _compositeDisposable.Dispose();
            _compositeDisposable.Clear();
        }

        private void BindWalletView()
        {
            _coins
                .Subscribe(count => OnViewModelChanged(count, _coinsLabel.Value))
                .AddTo(_compositeDisposable);

            _coinsLabel
                .Subscribe(label => OnViewModelChanged(_coins.Value, label))
                .AddTo(_compositeDisposable);
        }

        private void OnViewModelChanged(int coinValue, string coinLabel) => 
            _walletView.Redraw(coinLabel, coinValue);

        private void OnCoinCollected(int coins)
        {
            if (coins < 0)
                throw new ArgumentOutOfRangeException(nameof(coins));
            
            _walletModel.Coins.Value += coins;
        }

        private void BindCoinCollector()
        {
            _coinCollector.CoinCollected
                .Subscribe(coins => OnCoinCollected(coins))
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