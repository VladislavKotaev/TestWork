using TestWork.Buildings;
using TestWork.DI.Core;
using UnityEngine;
using UnityEngine.UI;

namespace TestWork.UI {
    public class ResourceBuildingWindow :  ProductionBuildingWindow, IInjectable {
        [SerializeField] private Button _nextRecipeButton;
    
        public override WindowType Type => WindowType.ResourceBuilding;
        protected override BaseProductionBuilding _baseProductionBuilding => _productionBuilding;
    
        private ProductionBuilding _productionBuilding;
    
        public void Construct(WindowsController windowsController) {
            windowsController.AddWindow(this);
            _nextRecipeButton.onClick.AddListener(OnPressRecipeButton);
            _onOffProducingButton.onClick.AddListener(OnPressOnOffProducingButton);
        }


        public void SetBuilding(ProductionBuilding productionBuilding) {
            _productionBuilding = productionBuilding;
            ShowRecipeOutput(_productionBuilding.ActualRecipe);
        }
    
        private void OnPressRecipeButton() {
            if (_productionBuilding == null) {
                ShowRecipeOutput(null);
            } else {
                ShowRecipeOutput(_productionBuilding.NextRecipe());
            }
        }

    }
}