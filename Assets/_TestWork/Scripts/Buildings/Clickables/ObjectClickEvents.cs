using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TestWork.Buildings.Clickables {
    public class ObjectClickEvents : MonoBehaviour, IPointerClickHandler {
        public Action OnClick { get; set; }

        public void OnPointerClick(PointerEventData eventData) {
            OnClick?.Invoke();
        }
    
    }
}