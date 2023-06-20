using TestWork.Buildings;
using TestWork.Crafting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestWork.UI {
    public abstract class ProductionBuildingWindow : MonoBehaviour, IWindow {
        [SerializeField] protected Button _onOffProducingButton;
        [SerializeField] protected Image _outputResourceImage;
        [SerializeField] protected TextMeshProUGUI _producingButtonText;
    
        public abstract WindowType Type { get; }
        protected abstract BaseProductionBuilding _baseProductionBuilding { get; }
    
        private const string _startProducingText = "Start";
        private const string _stopProducingText = "Stop";


        public void Open() {
            gameObject.SetActive(true);
        }
    
        public void Close() {
            gameObject.SetActive(false);
        }
    
        /// <summary>
        /// Если понадобится расширять систему, здесь можно легко дописать вывод ресурсов по слотам для рецептов, которые создают больше 1 ресурса
        /// </summary>
        protected void ShowRecipeOutput(Recipe recipe) {
            if (recipe == null || recipe.OutputItems.Length == 0) {
                _outputResourceImage.sprite = null;
                _producingButtonText.text = _startProducingText;
                _onOffProducingButton.interactable = false;
            } else {
                _outputResourceImage.sprite = recipe.OutputItems[0].Item.Icon;
                _producingButtonText.text = _baseProductionBuilding.IsWorking ? _stopProducingText : _startProducingText;
                _onOffProducingButton.interactable = true;
            }
        }

        protected void OnPressOnOffProducingButton() {
            if (_baseProductionBuilding != null) {
                _baseProductionBuilding.IsWorking = !_baseProductionBuilding.IsWorking;
                _producingButtonText.text = _baseProductionBuilding.IsWorking ? _stopProducingText : _startProducingText;
            }
        }
    
    }
}
