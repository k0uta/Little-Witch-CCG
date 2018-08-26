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


	public string art;
	public Sprite Art { get; set; }

	public new string name;

	[SerializeField, Multiline]
	public string descripion;


	public int energyLimit;


	public CardType type;
	public CardSubType subType;
	public List<Keyword> keywords;




	//TODO: RUNTIME VARIABLES FOR IN-GAME CARD
	public CardPlayedFrom PlayedFrom { get; set; }
	public int CurrentEnergy { get; set; }
	public List<CardMark> Marks { get; set; }


}
