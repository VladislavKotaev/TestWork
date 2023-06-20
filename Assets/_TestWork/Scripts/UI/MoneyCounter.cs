using TestWork.DI.Core;
using TestWork.GameStateControllers;
using TMPro;
using UnityEngine;

namespace TestWork.UI {
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class MoneyCounter : MonoBehaviour, IInjectable {
        private const string _textBeforeCounter = "Money: ";
        private TextMeshProUGUI _moneyText;
    
        public void Construct(MoneyController moneyController) {
            _moneyText = GetComponent<TextMeshProUGUI>();
            moneyController.OnMoneyCountChanged += OnMoneyCountChanged;
            OnMoneyCountChanged(moneyController.Money);
        }

        private void OnMoneyCountChanged(int money) {
            _moneyText.text = _textBeforeCounter + money;
        }
    
    }
}
