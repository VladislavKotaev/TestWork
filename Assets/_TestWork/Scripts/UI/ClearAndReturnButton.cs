using TestWork.DI.Core;
using TestWork.Saving;
using UnityEngine;
using UnityEngine.UI;

namespace TestWork.UI {
    [RequireComponent(typeof(Button))]
    public class ClearAndReturnButton : MonoBehaviour, IInjectable {
        public void Construct(StartReturner startReturner) {
            GetComponent<Button>().onClick.AddListener(startReturner.ReturnAndClear);
        }
    
    }
}