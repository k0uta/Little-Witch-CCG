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
		ToggleCell (false);
	}

	public void OnConditionChanged(List<Condition> conditions, int cellIndex){
		
		//Saves changed Condition into Rule

		var c = conditions [cellIndex];
		c.type = (Condition.ConditionType)dropdownType1.value;
		c.compareType = (Condition.CompareType)dropdownType2.value;
		c.valueToCompare = value.text;
	}

	public void OnEffectChanged(List<Effect> effects, int cellIndex){
		
		//Saves changed Effect into Rule

		var e = effects [cellIndex];
		e.type = (Effect.EffectType)dropdownType1.value;
		e.targetType = (Effect.EffectTargetType)dropdownType2.value;
		e.effectValue = value.text;
	}

	public void ToggleCell(bool value){
		this.gameObject.SetActive (value);
		IsBeingUsed = gameObject.activeSelf;
	}

	public void UpdateCellInfo(int indexType1, int indexType2, string inputValue){
		dropdownType1.value = indexType1;
		dropdownType2.value = indexType2;
		value.text = inputValue;
	}

	public void ResetCellInfo(){
		dropdownType1.value = 0;
		dropdownType2.value = 0;
		value.text = "";
		IsBeingUsed = false;
	}
}
