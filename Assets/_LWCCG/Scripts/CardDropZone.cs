using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LWCCG
{
    public class CardDropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField]
        private PlayerSlot playerSlot;

        [SerializeField]
        private bool lockDrag;
        public void OnDrop(PointerEventData eventData)
        {
            DraggableCard draggableCard = eventData.pointerDrag.GetComponent<DraggableCard>();

            if (this.playerSlot != draggableCard.playerSlot)
                return;

            // After everything
            draggableCard.Dock(this);
            if (lockDrag)
            {
                draggableCard.DisableDrag();
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            // throw new System.NotImplementedException();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            // throw new System.NotImplementedException();
        }
    }
}