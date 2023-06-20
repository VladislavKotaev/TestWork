using System;
using TestWork.Items;
using UnityEngine;

namespace TestWork.Saving {
    [System.Serializable]
    public class SaveData {
        [SerializeField] private bool _isInitialized = false;
        [SerializeField] private ResourceNameCountPair[] _nameCountPairs;
        [SerializeField] private int _moneyCount;
        [SerializeField] private int _resourceBuildingsCount = 1;

        public bool IsInitialized {
            get => _isInitialized;
            set => _isInitialized = value;
        }

        public ResourceNameCountPair[] NameCountPairs {
            get => _nameCountPairs;
            set => _nameCountPairs = value;
        }

        public int MoneyCount {
            get => _moneyCount;
            set => _moneyCount = value;
        }
    
        public int ResourceBuildingsCount {
            get => _resourceBuildingsCount;
            set => _resourceBuildingsCount = value;
        }

        public void Clear() {
            _isInitialized = false;
            _nameCountPairs = Array.Empty<ResourceNameCountPair>();
            _moneyCount = 0;
            _resourceBuildingsCount = 1;
        }
    
    }
}
