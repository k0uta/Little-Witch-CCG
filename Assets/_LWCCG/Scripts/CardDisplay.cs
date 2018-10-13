using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace LWCCG
{
    public class CardDisplay : MonoBehaviour
    {

        public Card card;

        public Text titleText;

        public Text descriptionText;

        public Image artworkImage;

        public virtual void Start()
        {
            titleText.text = card.title;
            descriptionText.text = card.description;
            artworkImage.sprite = card.artwork;
        }
    }
}