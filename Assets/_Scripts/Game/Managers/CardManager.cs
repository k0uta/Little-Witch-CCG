using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class CardManager
{


    static public InGameCard createNewInGameCard(GameObject cardObject, Card cardData)
    {

        var newCard = new InGameCard();

        newCard.NameText.text = cardData.Name;
        newCard.DescriptionText.text = cardData.Description;
        newCard.EnergyLimitText.text = cardData.energyLimit.ToString();

        GameObject instance = Object.Instantiate(cardObject);

        return null;
    }
    /*
    static public Card Create_New_Card(string name,
                        string flavorText,
                        Card.CardType type,
                        string creatureType,
                        List<Keyword> keywords,
                        Sprite art){

        var newCard = new Card();

        newCard.cardId = 0; // GET NEXT SEQUENCIAL
        newCard.art = art;

        newCard.name = name;

        newCard.PlayedFrom = Card.CardPlayedFrom.Hand;
        newCard.CurrentEnergy = 0;
        newCard.Marks = new List<Card.CardMark>();


        return newCard;

    }
    */

    /*
    static public Rule Create_Rule(List<Condition> conditions, List<Effect> effects){
        
        var newRule = new Rule();

        newRule.Conditions = conditions;
        newRule.Effects = effects;

        return newRule;
    }


    static public Keyword Create_Keyword(Keyword.KeywordType type, List<Rule> rules){

        var newKeyword = new Keyword();

        newKeyword.Type = type;
        newKeyword.Rules = rules;

        return newKeyword;

    }
        
    static public Condition Create_Condition(Condition.ConditionType type){

        var newCondition = new Condition();

        newCondition.Type = type;

        return newCondition;
            
    }
    */

    static public bool No_Conditions()
    {
        return true;
    }

    static public bool Card_Is_Of_Type(Card c, Card.CardType cardType)
    {

        //return c.Type == cardType;
        return true;

    }

    /*
    static public bool Number_Of_Card_Type_In_Play(Player p, string cardType, int value){
        
        var field = p.PlayerField;
        int count = 0;

        for(var i = 0; i <= field.Count - 1; i++){
            count += field[i].Type == cardType ? 1 : 0;
        }

        return count >= value;
    }
    */

    static public bool Card_Name_Is(Card c, string name)
    {

        //return c.Name == name;
        return true;

    }
    /*
    static public bool Card_In_Control(Player p, Card c){

        return p.PlayerField.Exists(x => x == c);

    }

    static public bool Card_Name_On_Field(Player p, Card c){

        return p.PlayerField.Exists(x => x.Name == c.Name);

    }

    static public bool Card_Creature_Type_On_Field(Player p, Card c){

        return p.PlayerField.Exists(x => x.CreatureType == c.CreatureType);

    }
    */

    /*
    static public bool Card_Was_Played_From(Card c, Card.CardPlayedFrom playedFrom){

        return c.PlayedFrom == playedFrom;

    }

    static public bool Card_Name_Already_Played(Card c, string name){
        return true;
        // ON HOLD
    }

    static public bool Card_Type_Already_Played(Card c, Card.CardType type){
        return true;
        // ON HOLD
    }

    static public bool Card_Has_Mark(Card c, Card.CardMark mark){
        
        return c.Marks.Exists(x => x == mark);

    }
    */

    /*
    static public bool Card_Current_Power_Is(Card c, int powerValue, Condition.CompareType compare){
        
        switch(compare){
            case Condition.CompareType.Bigger:
                return c.CurrentPower >= powerValue;

            case Condition.CompareType.Same:
                return c.CurrentPower == powerValue;

            case Condition.CompareType.Smaller:
                return c.CurrentPower <= powerValue;

            default:
                return false;
        }

    }
    */

}
