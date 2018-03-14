using System.Collections;
using System.Collections.Generic;

public class BoardObject{

	public enum ObjectType {
		Player,
		PlayerHand,
		Deck,
		DiscardPile,
		Card,
	}

	public ObjectType Type { get; set; }
}
