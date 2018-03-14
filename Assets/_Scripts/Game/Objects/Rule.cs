using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Rule {

	public enum RuleType{
		Default_And,
		Default_Or,
		Choose_Any,
		Choose_Number,
	}

	public RuleType type;
	public List<Condition> conditions;
	public List<Effect> effects;

}
