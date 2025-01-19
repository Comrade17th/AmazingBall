using UnityEngine;
using Zenject;
using TMPro;
using UniRx;

namespace _Project.Codebase.Core.Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsTMPro;

        private CompositeDisposable _compositeDisposable = new();
        private WalletViewModel _walletViewModel;

        //[Inject]
        private void  Construct(WalletViewModel walletViewModel)
        {
            _walletViewModel = walletViewModel;

            BindWalletViewModel();
        }
        
        private void OnDestroy()
        {
            _compositeDisposable.Dispose();
            _compositeDisposable.Clear();
        }

        private void BindWalletViewModel()
        {
            _walletViewModel.Coins
                .Subscribe(count => OnCoinsChanged(count))
                .AddTo(_compositeDisposable);

            _walletViewModel.CoinsLabel
                .Subscribe(label => OnCoinsLabelChanged(label))
                .AddTo(_compositeDisposable);
        }

        private void OnCoinsLabelChanged(string label)
        {
            RedrawView();
        }
        
        private void OnCoinsChanged(int count)
        {
            RedrawView();
        }
        
        private void RedrawView()
        {
            _coinsTMPro.text = $"{_walletViewModel.CoinsLabel.Value} {_walletViewModel.Coins.Value}";
        }
    }
}