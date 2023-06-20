using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestWork.UI {
    [RequireComponent(typeof(Button), typeof(Image))]
    public class ResourceBuildingsCountButton : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Color _inactiveColor;
        [SerializeField] private Color _activeColor;
    
        public Action<int> OnButtonPressed { get; set; }

        private Image _image;
        private int _buildingsCount;
    
        public void Init(int buildingsCount) {
            _buildingsCount = buildingsCount;
            _text.text = buildingsCount.ToString();
            GetComponent<Button>().onClick.AddListener(() => OnButtonPressed?.Invoke(_buildingsCount));
            _image = GetComponent<Image>();
        }

        public void UpdateColor(int choosedButton) {
            _image.color = _buildingsCount == choosedButton ? _activeColor : _inactiveColor;
        }
    
    }
}
