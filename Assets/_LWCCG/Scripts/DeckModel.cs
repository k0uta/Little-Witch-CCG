using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LWCCG
{
    public class DeckModel : MonoBehaviour
    {

        [SerializeField]
        private Deck baseDeck;

        private Deck deck;

        [SerializeField]
        private Text cardCountText;

        [SerializeField]
        private GameObject cardPrefab;

        [SerializeField]
        private GameObject creatureCardPrefab;

        [SerializeField]
        private Transform targetDock;

        [SerializeField]
        private PlayerSlot playerSlot;

        void UpdateCardCount()
        {
            cardCountText.text = string.Format("Count: {0}", deck.cards.Count);
        }

        void Start()
        {
            deck = Instantiate(baseDeck);
            deck.SpawnCards();
            deck.OnDeckUpdate += UpdateCardCount;
            deck.Shuffle();
        }

        public void Draw()
        {
            Card card = deck.Draw();

            // FIXME: I don't like doing fabric work within model class
            GameObject cardObject;
            if (card is CreatureCard)
            {
                cardObject = Instantiate(creatureCardPrefab);
            }
            else
            {
                cardObject = Instantiate(cardPrefab);
            }
            cardObject.name = card.title;
            cardObject.GetComponent<CardDisplay>().card = card;

            var draggableCard = cardObject.GetComponent<DraggableCard>();
            cardObject.GetComponent<DraggableCard>().Dock(targetDock.GetComponent<CardDropZone>());
            draggableCard.playerSlot = playerSlot;

            cardObject.transform.SetParent(targetDock);
        }
    }
}