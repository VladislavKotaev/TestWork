using System;
using TestWork.DI.Core;

namespace TestWork.GameStateControllers {
    public class MoneyController {
        public int Money { 
            get => _money;
            set {
                if (_money != value) {
                    _money = value;
                    OnMoneyCountChanged?.Invoke(_money);
                }
            } 
        }
        public Action<int> OnMoneyCountChanged { get; set; }

        private GameSettings _gameSettings;
        private int _money;
    
        public MoneyController() {
            _gameSettings = DIContainer.GetResolvedValue<GameSettings>();
        }
    }
}