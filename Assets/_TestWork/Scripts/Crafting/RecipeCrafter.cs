using TestWork.Inventory;
using TestWork.Items;

namespace TestWork.Crafting {
    /// <summary>
    /// Класс, отвечающий за процесс создания/переработки/сжигания ресурсов по рецепту.
    /// </summary>
    public class RecipeCrafter {
        // Можно добавить публичные события на начало и конец крафта, но пока они никак не используются, поэтому не стал.
    
        private IInventory _inventory;
        private ItemIdCountPair[] _inputItems;
        private ItemIdCountPair[] _outputItems;
    
        private float _timeToCreate;
        private float _timer;
        private bool _isStarted = false;
    
        public RecipeCrafter(Recipe recipe, float buildingPower, IInventory inventory) {
            _timeToCreate = recipe.Time * buildingPower;
            _inventory = inventory;
        
            _inputItems = new ItemIdCountPair[recipe.InputItems.Length];
            for (int i = 0; i < recipe.InputItems.Length; i++) {
                _inputItems[i] = new ItemIdCountPair(recipe.InputItems[i].Item.Id, recipe.InputItems[i].Count);
            }
        
            _outputItems = new ItemIdCountPair[recipe.OutputItems.Length];
            for (int i = 0; i < recipe.OutputItems.Length; i++) {
                _outputItems[i] = new ItemIdCountPair(recipe.OutputItems[i].Item.Id, recipe.OutputItems[i].Count);
            }
        }

        public void BreakProducing() {
            _isStarted = false;
        }
    
        /// <summary>
        /// В текущей реализации принцип такой:
        /// 1) В момент начала крафта все необходимые ингридиенты должны лежать в инвентаре
        /// 2) В случае их отсутствия, начало крафта висит в ожидании
        /// 3) Когда ресурсы появляются, таймер начинает идти. Ресурсы не блокируются, а проверку каждый кадр я не стал делать ради производительности.
        /// 4) Когда таймер дошёл до конца, снова делается проверка на наличие ресурсов.
        ///
        /// Есть более "правильный" способ - извлекать ресурсы из инвентаря в момент начала крафта, возвращать их назад при прерывании.
        /// Я не стал этого делать по причине того, что нужно будет дорабатывать систему сохранений, например запоминать,
        /// какое здание что крафтило, либо просто возвращать ресурсы перед сохранением.
        /// Это не что-то сложное, но потребует дополнительного времени.
        ///
        /// Есть альтернативный вариант - при любом прерывании уничтожать заблокированные ресурсы. Сурово, но вполне реалистичный вариант.
        /// Делать не стал, потому что скорее всего будет принято за баг.
        /// </summary>
        public void ManagedUpdate(float time) {
            if (_isStarted) {
                _timer += time;
                if (_timer > _timeToCreate) {
                    for (int i = 0; i < _outputItems.Length; i++) {
                        if (!_inventory.CanAdd(_outputItems[i].Id, _outputItems[i].Count)) {
                            return;
                        }
                    }
                    for (int i = 0; i < _inputItems.Length; i++) {
                        if (!_inventory.HasItem(_inputItems[i].Id, _inputItems[i].Count)) {
                            return;
                        }
                    }            
                    for (int i = 0; i < _inputItems.Length; i++) {
                        _inventory.Remove(_inputItems[i].Id, _inputItems[i].Count);
                    }
                    for (int i = 0; i < _outputItems.Length; i++) {
                        _inventory.Add(_outputItems[i].Id, _outputItems[i].Count);
                    }

                    _isStarted = false;
                    _timer = 0f;
                }
            }

            if (!_isStarted) {
                for (int i = 0; i < _inputItems.Length; i++) {
                    if (!_inventory.HasItem(_inputItems[i].Id, _inputItems[i].Count)) {
                        return;
                    }
                }

                _timer = 0f;
                _isStarted = true;
            }
        }
    
    
    }
}