using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Keyword {
	
	public enum KeywordType{
		Appear, //Enters the Field
		Disappear, // Leaves the Field
		Cycle, // At the end of a turn
		Bound, // When another Card enters the Field
		Energize, // When Card is given Power
		Resonance, // When a Spell is played
		Learn, // When a Player draws a Card
		Aura, // Active at all times on Field (not exactly a Keyword?)
		Special, // Breakes a game rule (makes no sense in here)
	}
		
	public KeywordType type;
	public List<Rule> rules;


}
