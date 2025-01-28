using UnityEngine;
using Zenject;
using TMPro;
using UniRx;

namespace _Project.Codebase.Core.Wallet
{
    public class WalletView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsTMPro;

        public void RedrawView(int coinValue, string coinLabel)
        {
            _coinsTMPro.text = $"{coinLabel} {coinValue}";
        }
    }
}