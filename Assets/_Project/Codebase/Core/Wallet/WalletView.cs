using UnityEngine;
using Zenject;
using TMPro;
using UniRx;

namespace _Project.Codebase.Core.Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsLabel;
        [SerializeField] private TextMeshProUGUI _coinsCount;

        private CompositeDisposable _compositeDisposable = new();
        private WalletViewModel _walletViewModel;

        [Inject]
        private void  Construct(WalletViewModel walletViewModel)
        {
            _walletViewModel = walletViewModel;
            
            _walletViewModel.Coins
                .Subscribe(count => OnCoinsChanged(count))
                .AddTo(_compositeDisposable);
        }

        private void OnDestroy()
        {
            _compositeDisposable.Dispose();
            _compositeDisposable.Clear();
        }

        private void OnCoinsChanged(int count)
        {
            _coinsCount.text = count.ToString();
        }
    }
}