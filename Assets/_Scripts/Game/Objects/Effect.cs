using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Effect {

	public enum EffectType{
		Deck_Draw,
		Deck_Search_To_Hand,
		Deck_Search_To_Field,
		Deck_Shuffle,
		Deck_Look_Top_Cards,
		Deck_Place_Cards_Top,
		Deck_Place_Cards_Bottom,

		Hand_Play,
		Hand_Discard,
		Hand_Reveal,

		DiscardPile_Search_To_Hand,
		DiscardPile_Search_To_Field,
		DiscardPile_Draw,

		Player_Gain_Action,
		Player_Lose_Action,
		Player_Damage,
		Player_Heal,

		Card_Current_Energy_Change,
		Card_Energy_Limit_Change,
		Card_Go_To_DiscardPile,
		Card_Return_To_Hand,
		Card_Receive_Effect,
		Card_Change_Effect_Value,
	
	}

	public enum EffectTargetType{
		Self,
		Opponent,
		Card,
	}

	public EffectType type;
	public EffectTargetType target;
	public string effectValue;

}
