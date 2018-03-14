using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "New Deck", menuName = "CCG/Deck", order = 1)]
public class Deck : ScriptableObject {

	public new string name;
	public List<Card> deckList;

}
