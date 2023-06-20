using TestWork.DI.Core;
using TestWork.Saving;
using UnityEngine;

namespace TestWork.Buildings {
    /// <summary>
    /// Отвечает исключительно за спавн ресурсных зданий.
    /// В полноценном проекте я бы сделал, чтобы все здания спавнились.
    /// Кстати, для полноценного проекта пайвоты зданий 
    /// </summary>
    public class ResourceBuildingsSpawner : MonoBehaviour, IInjectable {
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private float _offset;
        [SerializeField] private GameObject _buildingPrefab;

        public void Construct(SaveData saveData) {
            var buildingsLine = 0;
            var fullLines = saveData.ResourceBuildingsCount / 3;
            // При спавне 3+ зданий выстраиваются "ряды" (каждый ряд выглядит как угол с центральным зданием выше боковых) по 3 здания
            // точка _startPosition в итоге остаётся пустой, это точка начала отсчёта, а не спавна первого здания
            for (buildingsLine = 0; buildingsLine < fullLines; buildingsLine++) {
                Spawn(new Vector2Int(1, 1));
                Spawn(new Vector2Int(0, 1));
                Spawn(new Vector2Int(1, 0));
            }

            switch (saveData.ResourceBuildingsCount % 3) {
                // Если на последний ряд не хватает зданий, то спавнятся либо 2 боковых
                case 2:
                    Spawn(new Vector2Int(0, 1));
                    Spawn(new Vector2Int(1, 0));
                    break;
                // либо одно центральное в зависимости от нужного количества
                case 1:
                    Spawn(new Vector2Int(1, 1));
                    break;
            }

            void Spawn(Vector2Int additionalOffset) {
                DISpawner.Instantiate(_buildingPrefab, _startPosition + 
                    new Vector3(_offset * (buildingsLine + additionalOffset.x), 
                    0f, _offset * (buildingsLine + additionalOffset.y)), 
                    _buildingPrefab.transform.rotation, transform);
            }
        
        }
    }
}
