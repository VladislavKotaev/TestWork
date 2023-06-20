using System.IO;
using TestWork.StaticData;
using UnityEngine;

namespace TestWork.Saving {
    public static class SaveDataLoader {
        public static SaveData LoadSaveData() {
            SaveData saveData = null;
            if (File.Exists(StringDatas.SaveFilePath)) {
                try {
                    saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(StringDatas.SaveFilePath));
                }
                catch {
                    Debug.LogWarning("Save file is corrupted");
                }
            }
            if (saveData == null) {
                saveData = new SaveData();
            }

            return saveData;
        }
    
    }
}
