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
        private Transform targetDock;

        void UpdateCardCount()
        {
            cardCountText.text = string.Format("Count: {0}", deck.cards.Count);
        }

        void Start()
        {
            deck = Instantiate(baseDeck);
            deck.OnDeckUpdate += UpdateCardCount;
            deck.Shuffle();
        }

        public void Draw()
        {
            Card card = deck.Draw();
            GameObject cardObject = Instantiate(cardPrefab);
            cardObject.name = card.title;
            cardObject.GetComponent<CardDisplay>().card = card;

            cardObject.GetComponent<DraggableCard>().Dock(targetDock);
            cardObject.transform.SetParent(targetDock);
        }
    }
}