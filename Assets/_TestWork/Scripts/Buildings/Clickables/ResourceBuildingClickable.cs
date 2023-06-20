using TestWork.UI;
using UnityEngine;

namespace TestWork.Buildings.Clickables {
    [RequireComponent(typeof(ObjectClickEvents))]
    public class ResourceBuildingClickable : ClickableWindowOpener {
        protected override IWindow OpenWindow() {
            var window = base.OpenWindow();
            ((ResourceBuildingWindow)window).SetBuilding(GetComponent<ProductionBuilding>());
            return window;
        }
    
    }
}
