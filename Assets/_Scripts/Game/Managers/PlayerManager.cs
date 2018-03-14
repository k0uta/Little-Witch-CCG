using System.Collections;
using System.Collections.Generic;


static public class PlayerManager{

	static public Player Create_Player(CardZone deck, string playerName){

		var newPlayer = new Player();

		newPlayer.PlayerCardZones = new List<CardZone>();
		newPlayer.PlayerCardZones.Add(Create_CardZone(CardZone.ZoneType.Deck, deck.ZoneSize));
		newPlayer.PlayerCardZones.Add(Create_CardZone(CardZone.ZoneType.DiscardPile, deck.ZoneSize));
		newPlayer.PlayerCardZones.Add(Create_CardZone(CardZone.ZoneType.TransitionPile, deck.ZoneSize));
		newPlayer.PlayerCardZones.Add(Create_CardZone(CardZone.ZoneType.Hand, 7));
		newPlayer.PlayerCardZones.Add(Create_CardZone(CardZone.ZoneType.CreatureField, 5));
		newPlayer.PlayerCardZones.Add(Create_CardZone(CardZone.ZoneType.EnchantmentField, 1));


		newPlayer.PlayerMaximumActions = 1;
		newPlayer.PlayerCurrentActions = 1;

		newPlayer.PlayerName = playerName;

		return newPlayer;
	}

	static public CardZone Create_CardZone(CardZone.ZoneType zoneType, int zoneSize){
		var newCardZone = new CardZone();

		newCardZone.ZoneCards = new List<Card>();
		newCardZone.ZoneSize = zoneSize;

		return newCardZone;
	}

	static private CardZone GetZoneInstanceByEnum(Player p, CardZone.ZoneType zoneType){

		return p.PlayerCardZones.Find(x => x.Type == zoneType);
		
	}

	//Moves a card from Zone A to Zone B.
	static public void MoveCard(Player p, int cardIndex, CardZone.ZoneType zoneTypeA, CardZone.ZoneType zoneTypeB){

		var zoneA = GetZoneInstanceByEnum(p, zoneTypeA);
		var zoneB = GetZoneInstanceByEnum(p, zoneTypeB);
		
		zoneB.ZoneCards.Add(zoneA.ZoneCards[cardIndex]);
		zoneA.ZoneCards.RemoveAt(cardIndex);
		
	}

	//Moves multiple cards from the Top of Zone A to the Top or Bottom of Zone B.
	static public void MoveCardFromTop(Player p, CardZone.ZoneType zoneTypeA, CardZone.ZoneType zoneTypeB, int numberOfTimes, bool moveToBottom){
		var zoneA = GetZoneInstanceByEnum(p, zoneTypeA);
		var zoneB = GetZoneInstanceByEnum(p, zoneTypeB);

		for (var i = 0; i < numberOfTimes; i++){

			if (moveToBottom)
				zoneB.ZoneCards.Add(zoneA.ZoneCards[0]);
			else
				zoneB.ZoneCards.Insert(0, zoneA.ZoneCards[0]);

			zoneA.ZoneCards.RemoveAt(0);
		}

	}
	
}
