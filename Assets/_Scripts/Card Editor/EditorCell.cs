using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EditorCell : MonoBehaviour {

	public TMP_Dropdown dropdownType1;
	public TMP_Dropdown dropdownType2;
	public TMP_InputField value;

	public bool IsBeingUsed { get; set; }

	// Use this for initialization
	void Awake () {
		ToggleCell ();
	}

	public void OnConditionChanged(List<Condition> conditions, int cellIndex){
		var c = conditions [cellIndex];
		c.type = (Condition.ConditionType)dropdownType1.value;
		c.compareType = (Condition.CompareType)dropdownType2.value;
		c.valueToCompare = value.text;
	}

	public void OnEffectChanged(List<Effect> effects, int cellIndex){
		var e = effects [cellIndex];
		e.type = (Effect.EffectType)dropdownType1.value;
		e.target = (Effect.EffectTargetType)dropdownType2.value;
		e.effectValue = value.text;
	}

	public void ToggleCell(){
		this.gameObject.SetActive (!gameObject.activeSelf);
		IsBeingUsed = gameObject.activeSelf;
	}
		
}
