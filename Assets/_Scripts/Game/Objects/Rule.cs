using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Rule {

	public enum RuleType{
		Default_And,
		Default_Or,

		Choose_Any,

		Choose_One,
		Choose_Two,
		Choose_Three,

		Choose_Up_To_Two,
		Choose_Up_To_Three,
	}

	public RuleType type;
	public List<Condition> conditions;
	public List<Effect> effects;

}
