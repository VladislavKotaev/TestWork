using TestWork.DI.Core;
using TestWork.UI;

namespace TestWork.GameStateControllers {
    public class GameFinisher {
        private GameSettings _gameSettings;
        private WindowsController _windowsController;
        private const WindowType _finalWindowType = WindowType.Final;
    
        public GameFinisher() {
            var moneyController = DIContainer.GetResolvedValue<MoneyController>();
            _gameSettings = DIContainer.GetResolvedValue<GameSettings>();
            _windowsController = DIContainer.GetResolvedValue<WindowsController>();

            moneyController.OnMoneyCountChanged += CheckGameFinish;
        }

        private void CheckGameFinish(int actualMoney) {
            if (actualMoney >= _gameSettings.MoneyToWin) {
                _windowsController.OpenWindow(_finalWindowType);
            }
        }
    
    }
}
