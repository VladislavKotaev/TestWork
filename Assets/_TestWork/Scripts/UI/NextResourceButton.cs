using System;
using TestWork.DI.Core;
using TestWork.Items;
using UnityEngine;
using UnityEngine.UI;

namespace TestWork.UI {
    [RequireComponent(typeof(Button))]
    public class NextResourceButton : MonoBehaviour, IInjectable {
        public Action<int> OnNextResourceButton { get; set; }
    
        private Button _button;
        private int _buttonId;

        public void Init(int id) {
            _buttonId = id;
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonPressed);
        }
    
        public void Show(ItemData itemData) {
            _button.image.sprite = itemData == null ? null : itemData.Icon;
        }

        private void OnButtonPressed() {
            OnNextResourceButton?.Invoke(_buttonId);    
        }

    }
}
