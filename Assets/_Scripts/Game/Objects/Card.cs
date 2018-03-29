using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "New Card", menuName = "CCG/Card", order = 0)]
public class Card : ScriptableObject {

	public enum CardType{
		Creature,
		Magic,
		Enchantment,
		Hero,
	}

	public enum CardCreatureType{
		Plant,
		Insect,
		Ethereal,
		Elemental,
		Machine,
	}

	public enum CardSet{
		Green,
		Blue,
	}

	public enum CardQuality{
		Common,
		Rare,
		Legendary,
	}

	public enum CardPlayedFrom{
		Hand,
		Deck,
		DiscardPile,
	}

	public enum CardMark{
		Stunned,
	}

	public int cardId;

	public Sprite art;
	public new string name;

	[SerializeField, Multiline]
	public string descripion;
	public CardType type;
	public CardCreatureType creatureType;
	public List<Keyword> keywords;

	public int energyLimit;


	//RUNTIME VARIABLES FOR IN-GAME CARD
	public CardPlayedFrom PlayedFrom { get; set; }
	public int CurrentEnergy { get; set; }
	public List<CardMark> Marks { get; set; }


}
