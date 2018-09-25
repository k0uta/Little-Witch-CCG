using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LWCCG
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Little Witch CCG/Card")]
    public class Card : ScriptableObject
    {

        public string title;

        public string description;

        public Sprite artwork;
    }
}