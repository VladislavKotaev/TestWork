using System.IO;
using TestWork.StaticData;
using UnityEngine;

namespace TestWork.Saving {
    public static class SaveDataWriter {
        public static void WriteSaveData(SaveData data) {
            try {
                using (var streamWriter = new StreamWriter(StringDatas.SaveFilePath)) {
                    streamWriter.Write(JsonUtility.ToJson(data));
                }
            }
            catch {
                Debug.LogWarning("Save writing is failed");
            }
        }
    
    }
}
