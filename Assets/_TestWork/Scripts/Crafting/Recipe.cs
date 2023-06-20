using TestWork.Items;
using UnityEngine;

namespace TestWork.Crafting {
    /// <summary>
    /// Можно создавать рецепты для:
    /// - добывающих зданий (входящие ресурсы по нулям)
    /// - перерабатывающих зданий (есть входящие и исходящие ресурсы)
    /// - сжигающих ресурсы зданий (исходящие ресурсы по нулям)
    /// </summary>
    [CreateAssetMenu(menuName = "ScriptableObject/Recipe", order = 131)]
    public class Recipe : ScriptableObject {
        [SerializeField] private ItemCountPair[] _inputItems;
        [SerializeField] private ItemCountPair[] _outputItems;
        [SerializeField] private float _time = 1f;

        public ItemCountPair[] InputItems => _inputItems;
        public ItemCountPair[] OutputItems => _outputItems;
        public float Time => _time;
    }
}
