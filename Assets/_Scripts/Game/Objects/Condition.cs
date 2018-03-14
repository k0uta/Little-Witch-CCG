using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Condition {

	public enum ConditionType{
		Always_True,		

		Card_Is_Of_Type,
		Number_Of_Card_Type_In_Play,

		Card_Name_Is,
		Card_In_Control,
		
		Card_Name_On_Field,
		Card_Creature_Type_On_Field,

		Card_Was_Played_From,

		Card_Name_Already_Played,
		Card_Type_Already_Played,

		Card_Has_Mark,

		Card_Current_Power_Is,


		// DESTRINCHAR TODOS OS ATRIBUTOS DO JOGO
	}

	public enum CompareType{		
		Equal_To,
		Not_Equal_To,
		Greater_Than,
		Greater_Than_Or_Equal_To,
		Less_Than,
		Less_Than_Or_Equal_To,
	}
		
	public ConditionType type;
	public CompareType compareType;
	public string valueToCompare;

}
