using TestWork.Crafting;
using TestWork.Inventory;

namespace TestWork.Buildings {
    /// <summary>
    /// Класс можно использовать для любых производящих/добывающих ресурсы зданий, работающих с одним рецептом или сменяющимися по кругу рецептами.
    /// Можно легко создать наследников под сжигающие ресурсы здания (например создающие не относящиеся к ресурсам очки науки или тепла).
    /// </summary>
    public class ProductionBuilding : BaseProductionBuilding {
        public void Construct(IInventory inventory) {
            _inventory = inventory;
            _recipeCreators = new RecipeCrafter[_recipes.Length];
            for (int i = 0; i < _recipes.Length; i++) {
                _recipeCreators[i] = new RecipeCrafter(_recipes[i], _buildingPower, _inventory);
            }
        }

        public Recipe NextRecipe() {
            var oldRecipeId = _actualRecipeId;
            _actualRecipeId = _actualRecipeId >= _recipes.Length - 1 ? -1 : _actualRecipeId + 1;
            if (oldRecipeId != _actualRecipeId && oldRecipeId >= 0) {
                _recipeCreators[oldRecipeId].BreakProducing();
            }

            IsWorking = false;
            return ActualRecipe;
        }

    
    }
}