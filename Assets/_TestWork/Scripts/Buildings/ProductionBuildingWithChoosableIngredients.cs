using System;
using System.Linq;
using TestWork.Crafting;
using TestWork.DI.Core;
using TestWork.Inventory;
using TestWork.Items;

namespace TestWork.Buildings {
    public class ProductionBuildingWithChoosableIngredients : BaseProductionBuilding, IInjectable {
        // [SerializeField] private ItemData[] _availableResources;
    
        public Action<ItemData, int> OnResourceChanged { get; set; }
        public Action<Recipe> OnRecipeChanged { get; set; }

        private int _maxRecipeLength;
        private int[] _selectedResourceIds;
        private ItemDatasController _itemDatasController;
    
        public void Construct(IInventory inventory, ItemDatasController itemDatasController) {
            _inventory = inventory;
            _recipeCreators = new RecipeCrafter[_recipes.Length];
            for (int i = 0; i < _recipes.Length; i++) {
                _recipeCreators[i] = new RecipeCrafter(_recipes[i], _buildingPower, _inventory);
                if (_maxRecipeLength < _recipes[i].InputItems.Length) {
                    _maxRecipeLength = _recipes[i].InputItems.Length;
                }
            }

            _selectedResourceIds = new int[_maxRecipeLength];
            for (int i = 0; i < _selectedResourceIds.Length; i++) {
                _selectedResourceIds[i] = -1;
            }

            _itemDatasController = itemDatasController;
        }
    
        public void NextResource(int resourceSlot) {
            IsWorking = false;
            var selectedResource = _selectedResourceIds[resourceSlot] >= 0 ? _selectedResourceIds[resourceSlot] : 0;
            for (int i = 0; i < _itemDatasController.ResourceDatas.Length - 1; i++) {
                selectedResource = selectedResource < _itemDatasController.ResourceDatas.Length - 1 ? selectedResource + 1 : 0;
                if (_inventory.HasItem(_itemDatasController.ResourceDatas[selectedResource].Id, 1)) {
                    _selectedResourceIds[resourceSlot] = selectedResource;
                    OnResourceChanged?.Invoke(_itemDatasController.ResourceDatas[selectedResource], resourceSlot);
                    SelectRecipe();
                    break;
                }
            }
        }
    
        /// <summary>
        /// Код поддерживает рецепты с разным количеством входящих ресурсов.
        /// Если жестко ограничиваться двумя, можно было бы сделать проще.
        /// </summary>
        private void SelectRecipe() {
            var selectedResources = (int[])_selectedResourceIds.Clone();
            Array.Sort(selectedResources);
            if (_actualRecipeId >= 0) {
                _recipeCreators[_actualRecipeId].BreakProducing();
            }

            _actualRecipeId = -1;
            for (int recipeId = 0; recipeId < _recipes.Length; recipeId++) {
                var inputResources = _recipes[recipeId].InputItems.Select(r => r.Item.Id).ToArray();
                Array.Sort(inputResources);
                if (selectedResources.Length == inputResources.Length) {
                    var canCraft = true;
                    for (int i = 0; i < selectedResources.Length; i++) {
                        if (selectedResources[i] != inputResources[i]) {
                            canCraft = false;
                            break;
                        }
                    }

                    if (canCraft) {
                        _actualRecipeId = recipeId;
                        break;
                    }
                
                } else {
                    var incorrectResources = 0;
                    var maxIncorrectResources = selectedResources.Length - inputResources.Length;
                    for (int i = 0; i < selectedResources.Length; i++) {
                        if (selectedResources[i] != inputResources[i - incorrectResources]) {
                            incorrectResources++;
                        }
                    }

                    if (incorrectResources <= maxIncorrectResources) {
                        _actualRecipeId = recipeId;
                        break;
                    }
                
                }
            
            }
            OnRecipeChanged?.Invoke(_actualRecipeId >= 0 ? _recipes[_actualRecipeId] : null);
        }


    }
}
