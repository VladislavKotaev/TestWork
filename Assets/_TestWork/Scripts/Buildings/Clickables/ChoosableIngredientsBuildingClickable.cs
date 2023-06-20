using TestWork.UI;
using UnityEngine;

namespace TestWork.Buildings.Clickables {
    [RequireComponent(typeof(ObjectClickEvents))]
    public class ChoosableIngredientsBuildingClickable : ClickableWindowOpener {
        protected override IWindow OpenWindow() {
            var window = base.OpenWindow();
            ((ChoosableIngredientsBuildingWindow)window).SetBuilding(GetComponent<ProductionBuildingWithChoosableIngredients>());
            return window;
        }
    
    }
}