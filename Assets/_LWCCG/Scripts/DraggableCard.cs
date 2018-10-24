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
    public class DraggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
    {
        public bool dragDisabled;

        private CardDropZone dropZone;

        [SerializeField]
        public PlayerSlot playerSlot { get; set; }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (dragDisabled)
            {
                return;
            }

            this.transform.SetParent(this.transform.root);

            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (dragDisabled)
            {
                return;
            }
            this.transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (dragDisabled)
            {
                return;
            }
            this.transform.SetParent(dropZone.transform);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        public void Dock(CardDropZone targetDropZone)
        {
            dropZone = targetDropZone;
            this.transform.SetParent(dropZone.transform);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        public void DisableDrag()
        {
            dragDisabled = true;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("OnPointerClick");
            if (!dropZone.Energizing())
            {
                Debug.Log("Not Energizing");
                return;
            }

            var card = this.GetComponent<CardDisplay>().card;
            if (!(card is CreatureCard))
            {
                Debug.Log("Not Creature");
                return;
            }

            Debug.Log("Energizing");
            ((CreatureCard)card).Energize();

            dropZone.ToggleEnergizing();
        }
    }
}
