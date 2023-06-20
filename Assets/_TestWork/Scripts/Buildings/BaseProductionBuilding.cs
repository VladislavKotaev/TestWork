using TestWork.Crafting;
using TestWork.DI.Core;
using TestWork.Inventory;
using UnityEngine;

namespace TestWork.Buildings {
    public abstract class BaseProductionBuilding  : MonoBehaviour, IInjectable {
        [SerializeField] protected Recipe[] _recipes;
        public Recipe ActualRecipe => _actualRecipeId == -1 ? null : _recipes[_actualRecipeId];
        protected IInventory _inventory;
    
        /// <summary>
        /// В тексте тестового указано, что производительность должна указываться отдельно для каждого здания.
        /// Поскольку с точки зрения архитектуры имеет смысл дать возможность разным зданиям использовать различные рецепты,
        /// а рецептам - отличаться друг от друга в скорости создания, я решил разбить время создания на два отдельных множителя,
        /// один из которых прописывается в рецепте, а второй - коэффициент мощности выбранного здания.
        /// </summary>
        [SerializeField] protected float _buildingPower = 1f;
    
        protected int _actualRecipeId = -1;
        protected RecipeCrafter[] _recipeCreators;
    
        public bool IsWorking { get; set; }
    
        private void Update() {
            if (IsWorking && _actualRecipeId >= 0) {
                _recipeCreators[_actualRecipeId].ManagedUpdate(Time.deltaTime);
            }
        }
    
    }
}
