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

		Initialize_BottomSection ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		


	void Initialize_BottomSection(){

		PopulateBottomDropdowns ();

		keywordList.onValueChanged.AddListener (delegate {
			OnKeywordSelected();
		});

		rulesList.onValueChanged.AddListener (delegate {
			OnRuleSelected ();
		});

		ruleType.onValueChanged.AddListener (delegate {
			OnRuleTypeSelected();	
		});

		OnKeywordSelected ();
		UpdateKeywordListText ();

		rulesList.ClearOptions ();

	}

	public void OnKeywordButtonClicked_Plus(){

		var newKeyword = new Keyword ();
		newKeyword.type = (Keyword.KeywordType)keywordList.value;
		NewCard.keywords.Add (newKeyword);

		ToggleKeywordButtons ();
		UpdateKeywordListText ();

		AddRuleToCardCurrentKeyword ();
		OnRuleSelected ();
		ToggleRuleButtons ();

	}

	public void OnKeywordButtonClicked_Minus(){

		NewCard.keywords.Remove (FindCurrentKeywordOnCard());

		ToggleKeywordButtons ();
		UpdateKeywordListText ();

		rulesPanel.gameObject.SetActive (false);

	}

	public void OnRuleButtonClicked_Plus(){
		AddRuleToCardCurrentKeyword();
		ToggleRuleButtons ();
	}

	public void OnRuleButtonClicked_Minus(){
		
		var k = FindCurrentKeywordOnCard ();
		k.rules.Remove (k.rules[rulesList.value]);

		var tempValue = rulesList.value;

		rulesList.options.RemoveAt (tempValue);
		rulesList.value = tempValue-1;

		UpdateRulesListItemsText ();

		ToggleRuleButtons ();

		ruleType.value = (int)k.type;
	}

	void AddRuleToCardCurrentKeyword(){
		
		var k = FindCurrentKeywordOnCard ();

		k.rules = k.rules ?? new List<Rule>();

		var newRule = new Rule ();
		newRule.type = (Rule.RuleType)0;
		k.rules.Add (newRule);

		rulesList.AddOptions(new List<string> {"Rule ("+ k.rules.Count +")"});

		AddAllConditionsToCardCurrentRule ();
		AddAllEffectsToCardCurrentRule ();

		rulesPanel.gameObject.SetActive (true);
	}

	void AddAllConditionsToCardCurrentRule(){

		var r = FindCurrentRuleOnKeyword();
		r.conditions = r.conditions ?? new List<Condition> ();

		for (int i = 0; i < 6; i++) {
			
			var newCondition = new Condition();
			newCondition.type = (Condition.ConditionType)0;
			newCondition.compareType = (Condition.CompareType)0;
			newCondition.valueToCompare = "-";
			r.conditions.Add (newCondition);
		}

	}

	void AddAllEffectsToCardCurrentRule(){

		var r = FindCurrentRuleOnKeyword();
		r.effects = r.effects ?? new List<Effect> ();

		for (int i = 0; i < 6; i++) {

			var newEffect = new Effect();
			newEffect.type = (Effect.EffectType)0;
			newEffect.target = (Effect.EffectTargetType)0;
			newEffect.baseValue = 0;
			r.effects.Add (newEffect);
		}

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


	void OnKeywordSelected(){

		ToggleKeywordButtons ();
		selectedKeyword.text = keywordList.options[keywordList.value].text;

		var k = FindCurrentKeywordOnCard ();
		rulesPanel.gameObject.SetActive (k != null);


	}

	void OnRuleSelected(){
		selectedRule.text = rulesList.options [rulesList.value].text;

		ruleType.value = (int) FindCurrentRuleOnKeyword ().type;
	}

	void OnRuleTypeSelected(){
		FindCurrentRuleOnKeyword ().type = (Rule.RuleType) ruleType.value;
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

			c.value.text = "-";
		}

		foreach (EditorCell c in effectCellList) {
			c.dropdownType1.ClearOptions ();
			c.dropdownType2.ClearOptions ();
			PopulateDropdown<Effect.EffectType> (c.dropdownType1);
			PopulateDropdown <Effect.EffectTargetType> (c.dropdownType2);

			c.value.text = "0";
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
