using TestWork.DI.Core;
using TestWork.Saving;
using UnityEngine;

namespace TestWork.UI {
    public class ResourceBuildingsCountChooser : MonoBehaviour, IInjectable {
        private SaveData _saveData;
        private ResourceBuildingsCountButton[] _resourceBuildingsCountButtons;

        public void Construct(SaveData saveData) {
            _saveData = saveData;
            _resourceBuildingsCountButtons = GetComponentsInChildren<ResourceBuildingsCountButton>();
            for (int i = 0; i < _resourceBuildingsCountButtons.Length; i++) {
                _resourceBuildingsCountButtons[i].Init(i + 1);
                _resourceBuildingsCountButtons[i].OnButtonPressed += OnButtonPressed;
            }
            OnButtonPressed(_saveData.ResourceBuildingsCount);
        }

        private void OnButtonPressed(int resourceBuildingsCount) {
            _saveData.ResourceBuildingsCount = resourceBuildingsCount;
            foreach (var resourceBuildingsCountButton in _resourceBuildingsCountButtons) {
                resourceBuildingsCountButton.UpdateColor(resourceBuildingsCount);
            }
        }
    
    }
}
