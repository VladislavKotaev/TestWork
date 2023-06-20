using TestWork.Buildings;
using TestWork.DI.Core;
using TestWork.Items;
using TMPro;

namespace TestWork.UI {
    /// <summary>
    /// Можно добавить автоматическую подстройку количества выбираемых ресурсов под рецепт с самым большим количеством входных ресурсов из списка
    /// (со спавном нужного количества префабов кнопки переключения ресурса под HorizontalLayoutGroup, схожую систему можно посмотреть в окне инвентаря)
    /// Сами здания могут работать с разным количеством входных ресурсов.
    /// Аналогично можно добавить вывод более чем одного ресурса.
    /// </summary>
    public class ChoosableIngredientsBuildingWindow : ProductionBuildingWindow, IInjectable {
        protected override BaseProductionBuilding _baseProductionBuilding => _productionBuilding;
        public override WindowType Type => WindowType.ChoosableIngidientsBuilding;
    
        private ProductionBuildingWithChoosableIngredients _productionBuilding;
        private NextResourceButton[] _nextResourceButtons;
    
        public void Construct(WindowsController windowsController) {
            windowsController.AddWindow(this);
            _onOffProducingButton.onClick.AddListener(OnPressOnOffProducingButton);
            _producingButtonText = _onOffProducingButton.GetComponentInChildren<TextMeshProUGUI>();
            _nextResourceButtons = GetComponentsInChildren<NextResourceButton>(true);
            for (int i = 0; i < _nextResourceButtons.Length; i++) {
                _nextResourceButtons[i].Init(i);
                _nextResourceButtons[i].OnNextResourceButton += OnNextResourceButton;
            }
        }

        public void SetBuilding(ProductionBuildingWithChoosableIngredients productionBuilding) {
            if (_productionBuilding != productionBuilding && _productionBuilding != null) {
                _productionBuilding.OnRecipeChanged -= ShowRecipeOutput;
                _productionBuilding.OnResourceChanged -= OnResourceChanged;
            } else {
                _productionBuilding = productionBuilding;
                _productionBuilding.OnRecipeChanged += ShowRecipeOutput;
                _productionBuilding.OnResourceChanged += OnResourceChanged;
            }
            ShowRecipeOutput(_productionBuilding.ActualRecipe);
        }

        private void OnResourceChanged(ItemData itemData, int resourceButtonId) {
            _nextResourceButtons[resourceButtonId].Show(itemData);
        }

        private void OnNextResourceButton(int resourceButtonId) {
            if (_productionBuilding != null) {
                _productionBuilding.NextResource(resourceButtonId);
            }
        }

    }
}
