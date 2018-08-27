using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Condition {

	public enum ConditionType{
		Always_True,
		Decision_By_Player,

		Card_Type_Is,
		Card_Subtype_Is,
		Number_Of_Card_Type_In_Play_Is,

		Card_Name_Is,
		Card_Name_In_Control_Is,
		
		Card_Name_On_Field_Is,
		Card_Subtype_On_Field_Is,
		Card_Subtype_On_Field_Count_Is, // Adicionar um valueToCompare secundário pra esse funcionar

		Card_Was_Played_From,

		Card_Mark_Is,

		Card_Current_Power_Is,


		// DESTRINCHAR TODAS AS REGRAS DO JOGO
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
	public string valuesToCompare;

}
