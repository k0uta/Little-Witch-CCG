using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LWCCG
{
    [CreateAssetMenu(fileName = "New Deck", menuName = "Little Witch CCG/Deck")]
    public class Deck : ScriptableObject
    {
        [System.Serializable]
        public class CardEntry
        {
            public Card card;
            public int quantity;
        }

        public string title;

        public List<Card> cards;

        public List<CardEntry> cardList;

        public delegate void DeckHandler();
        public DeckHandler OnDeckUpdate;

        public void SpawnCards()
        {
            foreach (var cardEntry in cardList)
            {
                for (int i = 0; i < cardEntry.quantity; i++)
                {
                    var card = cardEntry.card;
                    cards.Add(Object.Instantiate(card) as Card);
                }
            }
        }

        public void Shuffle()
        {
            cards.Shuffle();
            UpdateDeck();
        }

        public Card Draw()
        {
            if (cards.Count <= 0)
                throw new System.Exception("No more cards to draw");

            int lastIndex = cards.Count - 1;
            Card card = cards[lastIndex];
            cards.RemoveAt(lastIndex);

            UpdateDeck();

            return card;
        }

        void UpdateDeck()
        {
            if (OnDeckUpdate != null)
                OnDeckUpdate();
        }
    }
}