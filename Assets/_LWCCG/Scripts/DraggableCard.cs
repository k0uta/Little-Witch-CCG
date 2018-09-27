using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LWCCG
{
    public enum PlayerSlot
    {
        Player1,
        Player2
    }
    public class DraggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {

        private Transform dockTransform;

        private bool dragDisabled;

        [SerializeField]
        public PlayerSlot playerSlot { get; set; }

        public void OnBeginDrag(PointerEventData eventData)
        {
            dockTransform = this.transform.parent;
            this.transform.SetParent(this.transform.root);

            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            this.transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            this.transform.SetParent(dockTransform);
            GetComponent<CanvasGroup>().blocksRaycasts = !dragDisabled;
        }

        public void Dock(Transform targetTransform)
        {
            dockTransform = targetTransform;
        }

        public void DisableDrag()
        {
            dragDisabled = true;
        }
    }
}
