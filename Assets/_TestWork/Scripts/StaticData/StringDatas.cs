using UnityEngine;

namespace TestWork.StaticData {
    public static class StringDatas {
        public static string SaveFilePath => Application.persistentDataPath + "/save.json";
    }
}
