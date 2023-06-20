using TestWork.DI.Core;

namespace TestWork.Saving {
    public class SaveClearer {
        private SaveData _saveData;
    
        public SaveClearer() {
            _saveData = DIContainer.GetResolvedValue<SaveData>();
        }

        public void ClearSave() {
            _saveData.Clear();
        }
    
    }
}
