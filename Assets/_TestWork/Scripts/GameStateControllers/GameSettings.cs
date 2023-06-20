using UnityEngine;

namespace TestWork.GameStateControllers {
    [CreateAssetMenu(menuName = "ScriptableObject/GameSettings", order = 132)]
    public class GameSettings : ScriptableObject {
        [SerializeField] private int _moneyToWin = 500;

        public int MoneyToWin => _moneyToWin;
    }
}
