using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class EffectsManager {

	/*
	static public Effect Create_Effect(Effect.EffectType type, int value){
		
		var newEffect = new Effect();

		newEffect.Type = type;
		newEffect.Value = value;

		return newEffect;

	}

	static public void Run_Effect(Effect e, 
					Player caster,
					Player playerTarget = null,
					Card cardTarget = null){

		switch(e.Type){
			case Effect.EffectType.Deck_Draw:
				break;
			default:
				break;
		}

		
	}
	*/

	/*
	========================================================================================



	static public void Deck_Draw(Player p){

		var deck = p.PlayerDeck;
		var cardToDraw = deck[0];

		PlayerManager.Hand_Add_Card(p, cardToDraw);
		PlayerManager.Deck_Remove_Card(p, cardToDraw);

	}

	static public void Deck_Search(Player p, Card target, bool toHand){
		var deck = p.PlayerDeck;
		
		var cardFound = deck.Find(x => x.Name == target.Name);

		if(toHand)
			PlayerManager.Hand_Add_Card(p, cardFound);
		else
			PlayerManager.Field_Add_Card(p, cardFound);
					
		PlayerManager.Deck_Remove_Card(p, cardFound);

	}

	static public void Deck_Shuffle(Player p){
		
		var deck = p.PlayerDeck;

		// Fisher–Yates Shuffle
		int n = deck.Count - 1;

		while(n > 0){
			n--;
			int k = Random.Range(0, n + 1); // Random.Range(int,int) is Inclusive, Exclusive
			var value = deck[k];
			deck[k] = deck[n];
			deck[n] = value;
		}
	}

	static public void Deck_Look_Top_Cards(){
		
	}

	static public void Deck_Place_Cards_Top(){
		
	}

	static public void Deck_Place_Cards_Bottom(){
		
	}

	/*
	========================================================================================

	static public void Hand_Play(Player p, List<int> cardIndexes){
		
		var hand = p.PlayerHand;
		var field = p.PlayerField;

		for (var i = 0; i <= cardIndexes.Count - 1; i++){

			var card = hand[cardIndexes[i]];
			
			PlayerManager.Field_Add_Card(p, card);
			PlayerManager.Hand_Remove_Card(p, cardIndexes[i]);

		}

	}


	static public void Hand_Discard(Player p, List<int> cardIndexes){

		var hand = p.PlayerHand;
		var discardPile = p.PlayerDiscardPile;

		for (var i = 0; i <= cardIndexes.Count - 1; i++){

			var card = hand[cardIndexes[i]];

			PlayerManager.DiscardPile_Add_Card(p, card);
			PlayerManager.Hand_Remove_Card(p, cardIndexes[i]);

		}
	}

	static public void Hand_Reveal(Player p){
		var hand = p.PlayerHand;

		for (var i = 0; i <= hand.Count - 1; i++){
			Debug.Log(hand[i].Name); // IMPLEMENT ACTUAL REVEAL OF HAND
		}
	}

	/*
	========================================================================================


	static public void DiscardPile_Search(Player p, Card target, bool toHand){
		
		var discardPile = p.PlayerDiscardPile;

		var cardFound = discardPile.Find(x => x.Name == target.Name);


		if(toHand)
			PlayerManager.Hand_Add_Card(p, cardFound);
		else
			PlayerManager.Field_Add_Card(p, cardFound);

		PlayerManager.DiscardPile_Remove_Card(p, cardFound);
		

	}


	static public void DiscardPile_Draw(Player p){
		
	}


	/*
	========================================================================================


	static public void Player_Gain_Action(Player p, int value, bool permanent){
		
		if (permanent)
			p.MaximumActions += value;
		else
			p.CurrentActions += value;
	}

	static public void Player_Damage(Player p, int value){
		
		var deck = p.PlayerDeck;
		var discardPile = p.PlayerDiscardPile;
		
		for (var i = 0; i <= value; i++){
			PlayerManager.DiscardPile_Add_Card(p, deck[0]);
			PlayerManager.Deck_Remove_Top_Card(p);
		}		

	}

	static public void Player_Heal(Player p, int value){

		var deck = p.PlayerDeck;
		var discardPile = p.PlayerDiscardPile;

		for (var i = 0; i <= value; i++){
			PlayerManager.Deck_Add_Card(p, discardPile[0]);
			PlayerManager.DiscardPile_Remove_Top_Card(p);
		}
		
	}

	/*
	========================================================================================


	static public void Card_Power_Change(Card c, int value){
		
		c.CurrentEnergy += value;

	}

	static public void Card_Go_To_DiscardPile(Player p, List<int> cardIndexes){
		
		var discardPile = p.PlayerDiscardPile;
		var field = p.PlayerField;

		for (var i = 0; i <= cardIndexes.Count - 1; i++){

			var card = field[cardIndexes[i]];

			PlayerManager.DiscardPile_Add_Card(p, card);
			PlayerManager.Field_Remove_Card(p, cardIndexes[i]);
			
		}

	}

	
	static public void Card_Return_To_Hand(Player p, List<int> cardIndexes){
		
		var hand = p.PlayerHand;
		var field = p.PlayerField;

		for (var i = 0; i <= cardIndexes.Count - 1; i++){

			var card = field[cardIndexes[i]];

			PlayerManager.Hand_Add_Card(p, card);
			PlayerManager.Field_Remove_Card(p, cardIndexes[i]);
			
		}

	}


	static public void Card_Receive_Effect(Card c, int keywordIndex, int ruleIndex, Effect e){
		
		c.Keywords[keywordIndex].Rules[ruleIndex].Effects.Add(e);

	}

	static public void Card_Change_Effect_Value(Card c, int keywordIndex, int ruleIndex, int effectIndex, int newValue){
		
		c.Keywords[keywordIndex].Rules[ruleIndex].Effects[effectIndex].Value = newValue;

	}

	*/
}
