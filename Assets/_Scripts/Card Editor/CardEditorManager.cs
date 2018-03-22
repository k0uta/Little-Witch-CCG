using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardEditorManager : MonoBehaviour {

	public TMP_InputField cardName;
	public TMP_InputField cardDescription;

	public TMP_Dropdown cardType;
	public TMP_Dropdown creatureType;
	public TMP_Dropdown cardQuality;

	public TMP_Dropdown keywordList;
	public TMP_Dropdown rulesList;
	public TMP_Dropdown ruleType;

	public TMP_Text selectedKeyword;
	public TMP_Text keywordListText;
	public TMP_Text selectedRule;

	public GameObject rulesPanel;
	public GameObject conditionsPanel;
	public GameObject effectsPanel;

	public List<EditorCell> conditionCellList;
	public List<EditorCell> effectCellList;

	public Button btnKeywordPlus;
	public Button btnKeywordMinus;
	public Button btnRulesPlus;
	public Button btnRulesMinus;
	public Button btnSave;

	public Card NewCard { get; set; }


	// Use this for initialization
	void Start () {
		NewCard = ScriptableObject.CreateInstance<Card> ();
		NewCard.keywords = new List<Keyword> ();

		PopulateOuterDropdowns();

		Initialize_UpperSection ();
		Initialize_BottomSection ();
	}
		
	void Initialize_UpperSection(){

		cardType.onValueChanged.AddListener (delegate {
			OnCardTypeValueChanged();
		});
	}

	void OnCardTypeValueChanged(){

		creatureType.gameObject.SetActive (cardType.value == (int)Card.CardType.Creature);
	}


	void Initialize_BottomSection(){

		PopulateBottomDropdowns ();

		keywordList.onValueChanged.AddListener (delegate {
			OnKeywordValueChanged();
		});

		rulesList.onValueChanged.AddListener (delegate {
			OnRuleValueChanged ();
		});

		ruleType.onValueChanged.AddListener (delegate {
			OnRuleTypeValueChanged();
		});
			

		OnKeywordValueChanged ();
		UpdateKeywordListText ();

		rulesList.ClearOptions ();

	}

	public void OnKeywordButtonClicked_Plus(){
		AddSelectedKeywordToCard ();

		ToggleKeywordButtons ();
		UpdateKeywordListText ();

		OnRuleButtonClicked_Plus ();
	}

	public void OnKeywordButtonClicked_Minus(){
		RemoveCurrentKeywordFromCard ();

		ToggleKeywordButtons ();
		UpdateKeywordListText ();

		rulesPanel.gameObject.SetActive (false);
	}

	public void OnRuleButtonClicked_Plus(){
		
		AddRuleToCurrentKeyword();

		UpdateRulesList ();
		OnRuleValueChanged ();

		ToggleRuleButtons ();

	}

	public void OnRuleButtonClicked_Minus(){
		
		RemoveRuleFromCurrentKeyword ();
		UpdateRulesListItemsText ();
		OnRuleValueChanged ();
		ToggleRuleButtons ();


	}

	// FAZER OS BOTÕES DE +/- DE CONDIÇÃO E EFEITO
	public void OnConditionButtonClicked_Plus(){
		AddEditorCell (conditionCellList);
	}

	public void OnConditionButtonClicked_Minus(){
		RemoveEditorCell (conditionCellList);
	}

	public void OnEffectButtonClicked_Plus(){
		AddEditorCell (effectCellList);
	}

	public void OnEffectButtonClicked_Minus(){
		RemoveEditorCell (effectCellList);
	}


	void AddSelectedKeywordToCard(){
		
		var newKeyword = new Keyword ();
		newKeyword.type = (Keyword.KeywordType)keywordList.value;
		NewCard.keywords.Add (newKeyword);
	}

	void RemoveCurrentKeywordFromCard(){
		
		NewCard.keywords.Remove (FindCurrentKeywordOnCard());

	}
		

	void AddRuleToCurrentKeyword(){
		
		var k = FindCurrentKeywordOnCard ();

		k.rules = k.rules ?? new List<Rule>();

		var newRule = new Rule ();
		newRule.type = (Rule.RuleType)0;
		k.rules.Add (newRule);

		AddConditionToCardRule (newRule);
		AddEffectToCardRule (newRule);

		rulesList.AddOptions(new List<string> {"Rule ("+ k.rules.Count +")"});

		rulesPanel.gameObject.SetActive (true);
	}

	void RemoveRuleFromCurrentKeyword(){
		
		var k = FindCurrentKeywordOnCard ();
		k.rules.Remove (k.rules[rulesList.value]);

		var tempValue = rulesList.value;

		rulesList.options.RemoveAt (tempValue);
		rulesList.value = tempValue-1;
		ruleType.value = (int)k.type;

	}

	void AddEditorCell(List<EditorCell> listToUse){

		//Picks the first Cell not being used and activates it.
		foreach (EditorCell ec in listToUse) {
			if (!ec.IsBeingUsed) {
				ec.ToggleCell (true);
				AddConditionToCardRule (FindCurrentRuleOnKeyword ());
				return;
			}
		}

	}

	void RemoveEditorCell(List<EditorCell> listToUse){

		//Picks the last Cell being used and deactivates it.
		for (int i = listToUse.Count-1; i >= 0; i--) {
			if (listToUse [i].IsBeingUsed) {
				listToUse [i].ToggleCell (false);
				RemoveConditionFromCardRule(FindCurrentRuleOnKeyword(), i);
				return;
			}
		}

	}

	void UpdateEditorsCells(){

		var r = FindCurrentRuleOnKeyword ();

		HideAllEditorsCells (conditionCellList);
		HideAllEditorsCells (effectCellList);

		for (int i = 0; i < r.conditions.Count; i++) {
			int valueType1 = (int)r.conditions [i].type;
			int valueType2 = (int)r.conditions [i].compareType;
			string inputValue = (string)r.conditions [i].valueToCompare;

			conditionCellList [i].ToggleCell (true);
			conditionCellList [i].UpdateCellInfo(valueType1, valueType2, inputValue);

		} 

		for (int i = 0; i < r.effects.Count; i++) {
			int valueType1 = (int)r.effects [i].type;
			int valueType2 = (int)r.effects [i].targetType;
			string inputValue = (string)r.effects [i].effectValue;

			effectCellList [i].ToggleCell (true);
			effectCellList [i].UpdateCellInfo(valueType1, valueType2, inputValue);
		}


	}

	void HideAllEditorsCells(List<EditorCell> listToUse){

		foreach (EditorCell ec in listToUse) {
			ec.ToggleCell (false);
		}

	}
		
	void AddConditionToCardRule(Rule r){

		r.conditions = r.conditions ?? new List<Condition> ();

		var newCondition = new Condition();
		newCondition.type = (Condition.ConditionType)0;
		newCondition.compareType = (Condition.CompareType)0;
		newCondition.valueToCompare = "";
		r.conditions.Add (newCondition);

	}

	void RemoveConditionFromCardRule(Rule r, int index){
		r.conditions.RemoveAt (index);
	}
		
	void AddEffectToCardRule(Rule r){

		r.effects = r.effects ?? new List<Effect> ();

		var newEffect = new Effect();
		newEffect.type = (Effect.EffectType)0;
		newEffect.targetType = (Effect.EffectTargetType)0;
		newEffect.effectValue = "";
		r.effects.Add (newEffect);

	}



	void ToggleRuleButtons(){
		var hasMoreThanOneRule = CardHasMoreThanOneRule ();
		btnRulesMinus.gameObject.SetActive (hasMoreThanOneRule);

	}

	void ToggleKeywordButtons(){
		var hasKeyword = CardHasKeyword ();
		btnKeywordPlus.gameObject.SetActive (!hasKeyword);
		btnKeywordMinus.gameObject.SetActive (hasKeyword);

	}


	void OnKeywordValueChanged(){

		ToggleKeywordButtons ();
		selectedKeyword.text = keywordList.options[keywordList.value].text;

		var k = FindCurrentKeywordOnCard ();
		rulesPanel.gameObject.SetActive (k != null);

		if (k != null) {
			UpdateRulesList ();
		}

	}
		

	void OnRuleValueChanged(){

		var r = FindCurrentRuleOnKeyword ();
		selectedRule.text = rulesList.options [rulesList.value].text;
		ruleType.value = (int) r.type;

		UpdateEditorsCells ();
	}
		

	void OnRuleTypeValueChanged(){
		FindCurrentRuleOnKeyword ().type = (Rule.RuleType) ruleType.value;
	}

	public void OnConditionChanged(EditorCell cell){
		cell.OnConditionChanged (FindCurrentRuleOnKeyword ().conditions, conditionCellList.FindIndex (x => x == cell));
	}
		

	public void OnEffectChanged(EditorCell cell){
		cell.OnEffectChanged (FindCurrentRuleOnKeyword ().effects, effectCellList.FindIndex (x => x == cell));
	}
		


	void UpdateKeywordListText(){
		keywordListText.text = "Keyword List {";

		for (int i = 0; i < NewCard.keywords.Count; i++) {
			
			keywordListText.text += NewCard.keywords[i].type.ToString();

			if(i != NewCard.keywords.Count - 1)
				keywordListText.text += ", ";
		}

		keywordListText.text += "}";
	}

	void UpdateRulesList(){
		rulesList.ClearOptions ();

		var listToAdd = new List<string> ();

		int i = 0;
		foreach (Rule r in FindCurrentKeywordOnCard().rules) {
			listToAdd.Add ("Rule (" + ++i + ")");
		}
		rulesList.AddOptions (listToAdd);
		UpdateRulesListItemsText ();
		rulesList.value = 0;


	}

	void UpdateRulesListItemsText(){
		
		int i = 0;

		foreach (TMP_Dropdown.OptionData o in rulesList.options) {
			o.text = "Rule (" + ++i + ")";
		}

	}

	void PopulateOuterDropdowns(){

		PopulateDropdown<Card.CardType> (cardType);
		PopulateDropdown<Card.CardCreatureType> (creatureType);
		PopulateDropdown<Card.CardQuality> (cardQuality);
		PopulateDropdown<Rule.RuleType> (ruleType);
		PopulateDropdown<Keyword.KeywordType> (keywordList);

	}

	void PopulateBottomDropdowns(){

		foreach (EditorCell c in conditionCellList) {
			c.dropdownType1.ClearOptions ();
			PopulateDropdown<Condition.ConditionType> (c.dropdownType1);

			c.value.text = "";
		}

		foreach (EditorCell c in effectCellList) {
			c.dropdownType1.ClearOptions ();
			c.dropdownType2.ClearOptions ();
			PopulateDropdown<Effect.EffectType> (c.dropdownType1);
			PopulateDropdown<Effect.EffectTargetType> (c.dropdownType2);

			c.value.text = "";
		}

	}

	void PopulateDropdown<K>(TMP_Dropdown d){

		List<string> tempList = new List<string> ();
		tempList.AddRange(Enum.GetNames (typeof(K)));

		d.ClearOptions ();
		d.AddOptions(tempList);

	}

	Rule FindCurrentRuleOnKeyword(){
		int valueToCompare = rulesList.value;
		var r = FindCurrentKeywordOnCard ().rules;
		return r[valueToCompare];
	}

	Keyword FindCurrentKeywordOnCard(){
		Keyword.KeywordType valueToCompare = (Keyword.KeywordType)keywordList.value;
		return NewCard.keywords.Find (x => x.type == valueToCompare);
	}

	bool CardHasKeyword(){
		return FindCurrentKeywordOnCard() != null;
	}

	bool CardHasMoreThanOneRule(){
		return FindCurrentKeywordOnCard ().rules.Count > 1;
	}

}
