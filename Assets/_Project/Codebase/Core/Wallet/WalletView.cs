using UnityEngine;
using TMPro;

namespace _Project.Codebase.Core.Wallet
{
    public class WalletView : MonoBehaviour, IWalletView
    {
        [SerializeField] private TextMeshProUGUI _textField;

        public void Redraw(string coinLabel, int coinValue) =>
            _textField.text = $"{coinLabel} {coinValue}";
    }

    public interface IWalletView
    {
        void Redraw(string label, int count);
    }
}