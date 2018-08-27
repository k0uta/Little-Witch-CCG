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

	public enum CardSubType{
		Plant,
		Insect,
		Ethereal,
		Elemental,
		Machine,
	}

	public enum CardModifier{
		Cant_Attack,
		Cant_Be_Swaped,
		Token,
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


	public Sprite Art { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }

	public int energyLimit;

	public CardType type;
	public List<CardSubType> subTypes;
	public List<CardModifier> modifiers;
	public List<Keyword> keywords;



	//TODO: RUNTIME VARIABLES FOR IN-GAME CARD
	public CardPlayedFrom PlayedFrom { get; set; }
	public int CurrentEnergy { get; set; }
	public List<CardMark> Marks { get; set; }


}
