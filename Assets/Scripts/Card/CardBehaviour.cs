using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum CardColor
{
	Black,
	Red
}

public enum CardSuits
{
	Hearts,
	Diamonds,
	Clubs,
	Spades
}

public class CardBehaviour : MonoBehaviour
{
	int value;
	CardColor color;
	CardSuits suits;

	Material frontMat;
	Material backMat;

	Transform anchorPoint;

	//Initilization
	private void Start()
	{
		value = -1;
		anchorPoint = null;
		color = default;
		suits = default;
	}

	//Interface
	public void SetCardAttributes(int val, CardColor cardColor, CardSuits cardSuits, Material face, Material back)
	{
		value = val;
		color = cardColor;
		suits = cardSuits;

		frontMat = face;
		backMat = back;
		
		//Debug.Log("Created " + value + " " + cardSuits.ToString());
	}
	
	public void ApplyMaterialsChanges()
	{
		GetComponent<SpriteRenderer>().sharedMaterial = frontMat;
	}

	public int GetCardValue()
	{
		return value;
	}

	public CardColor GetCardColor()
	{
		return color;
	}

	public CardSuits GetCardSuits()
	{
		return suits;
	}
}
