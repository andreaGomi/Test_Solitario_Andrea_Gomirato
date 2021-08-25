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

public enum TableZone
{
	Deck,
	Waste, 
	Tableau,
	Foundation
}

public class CardBehaviour : MonoBehaviour
{
	public Vector3 AnchorPoint { get; set; }
	public bool isSelectable { get; set; } = false;
	//public bool isSelectable = false;
	public bool IsCurrentlyHelded { get; set; } = false;
	public TableZone Zone { get; set; }

	int value;
	CardColor color;
	CardSuits suits;

	Material frontMat;
	Material backMat;
	int currentMatIndex;

	bool currentlyMoving;

	//Initilization
	private void Awake()
	{
		value = -1;
		color = default;
		suits = default;
		currentMatIndex = 0;	// 0 -> Face Material, 1 -> Back Material

		currentlyMoving = false;
		AnchorPoint = transform.position;
	}

	private void Start()
	{
		
	}

	//Interface
	public void SetCardAttributes(int val, CardColor cardColor, CardSuits cardSuits, TableZone tZone, Material face, Material back)
	{
		value = val;
		color = cardColor;
		suits = cardSuits;
		Zone = tZone;

		frontMat = face;
		backMat = back;
		
		//Debug.Log("Created " + value + " " + cardSuits.ToString());
	}
	
	public void SwapCardMaterial()
	{
		currentMatIndex = Mathf.Abs(currentMatIndex - 1);
		SpriteRenderer rnd = GetComponent<SpriteRenderer>();
		rnd.sharedMaterial = (currentMatIndex == 0) ? frontMat : backMat; 
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

	public void ReplaceCard()
	{
		if(!currentlyMoving)
			StartCoroutine(GoToPosition());
	}

	IEnumerator GoToPosition()
	{
		currentlyMoving = true;

		while((transform.position - AnchorPoint).magnitude > 0.001f)
		{
			transform.position = Vector3.MoveTowards(transform.position, AnchorPoint, 0.5f);
			//Vector3 dir = (AnchorPoint - transform.position).normalized;	
			//transform.position += dir * Time.deltaTime * cardAnimSpeed;
			yield return null;
		}

		currentlyMoving = false;
		transform.position = AnchorPoint;
	}
}
