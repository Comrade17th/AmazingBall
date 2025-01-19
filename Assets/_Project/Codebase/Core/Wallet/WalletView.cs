using UnityEngine;
using Zenject;
using TMPro;

namespace _Project.Codebase.Core.Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coins;
        
        private WalletViewModel _walletViewModel;

        [Inject]
        private void  Construct(WalletViewModel walletViewModel) => 
            _walletViewModel = walletViewModel;
        
        
    }
}