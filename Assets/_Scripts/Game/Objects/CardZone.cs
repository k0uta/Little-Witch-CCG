using System.Collections;
using System.Collections.Generic;


public class CardZone {

	public enum ZoneType{
		Deck,
		DiscardPile,
		TransitionPile,
		Hand,
		CreatureField,
		EnchantmentField,

	}

	public List<Card> ZoneCards { get; set; }
	public ZoneType Type { get; set; }
	public int ZoneSize{ get; set; }

}
