using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Effect {

	public enum EffectType{
		Deck_Draw,
		Deck_Search_Card_By_Player_To_Hand,
		Deck_Search_Card_By_Player_To_Field,
		Deck_Search_Card_By_Id_To_Hand,
		Deck_Search_Card_By_Id_To_Field,
		Deck_Shuffle,
		Deck_Look_Top_Cards,
		Deck_Place_Cards_Top,
		Deck_Place_Cards_Bottom,

		Hand_Play_Type_To_Field,
		Hand_Discard,
		Hand_Reveal,

		DiscardPile_Search_Card_By_Player_To_Hand,
		DiscardPile_Search_Card_By_Player_To_Field,
		DiscardPile_Search_Card_By_Id_To_Hand,
		DiscardPile_Search_Card_By_Id_To_Field,
		DiscardPile_Draw,

		Player_Gain_Action,
		Player_Lose_Action,
		Player_Damage,
		Player_Heal,

		Card_Current_Energy_Change,
		Card_Current_Energy_Transfer,
		Card_Energy_Limit_Change,
		Card_Go_To_DiscardPile,
		Card_Return_To_Hand,
		Card_Receive_Effect,
		Card_Change_Effect_Value,
	
	}

	// Alvo está atrelado ao efeito. Efeitos de Carta só tem Cartas como Alvo. Efeitos de Deck, Hand, DiscardPile e Player tem o jogador como Alvo.
	// Alvo deve ter sua classe.
	// Todo efeito possui um Alvo.

	public enum EffectTargetType{
		Self,
		Card_By_Choice,
		Card_By_Type,
		Card_By_Name,
		Controller,
		Opponent,

	}

	public EffectType type;
	public EffectTargetType targetType;
	public List<string> effectValues;

}
