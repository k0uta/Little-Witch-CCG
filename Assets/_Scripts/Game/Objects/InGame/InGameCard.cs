using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameCard : MonoBehaviour {

	public enum CardPlayedFrom{
		Hand,
		Deck,
		DiscardPile,
	}

	public enum CardMark{
		Stunned,
	}

	public GameObject cardInHandObject;
	public GameObject cardOnBoardObject;

	public Collider2D cardInHandCollider;
	public Collider2D cardOnBoardCollider;

	public Sprite Art { get; set; }

	public TextMeshPro NameText { get; set; }
	public TextMeshPro DescriptionText { get; set; }

	public TextMeshPro EnergyLimitText { get; set; }

	public TextMeshPro CurrentEnergyText { get; set; }
	public int CurrentEnergy { get; set; }

	public CardPlayedFrom PlayedFrom { get; set; }

	public List<CardMark> Marks { get; set; }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
