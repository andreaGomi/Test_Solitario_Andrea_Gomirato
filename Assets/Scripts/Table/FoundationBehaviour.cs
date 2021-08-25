using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundationBehaviour : MonoBehaviour
{
	[SerializeField] CardSuits suits;
	[SerializeField] List<CardBehaviour> pile;

	CardBehaviour cardEntered = null;

    // Start is called before the first frame update
    void Start()
    {
		pile = new List<CardBehaviour>();
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//Debug.Log("Enter a card");
		cardEntered = collision.gameObject.GetComponent<CardBehaviour>();
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		//Debug.Log("Exit a card");
		CardBehaviour card = collision.gameObject.GetComponent<CardBehaviour>();
		if (pile.Contains(card))
		{
			pile.Remove(card);
		}

		cardEntered = null;
	}

	

	// Update is called once per frame
	void Update()
    {
		if(cardEntered)
			ManageEnteredCard();
    }

	private void ManageEnteredCard()
	{
		if (cardEntered.IsCurrentlyHelded)
			return;

		if(cardEntered.GetCardSuits() != suits)
		{
			//Debug.Log("Seme Sbagliato..");
			cardEntered.ReplaceCard();
			cardEntered = null;
			return;
		}

		if(pile.Count == 0)	//Lista vuota
		{
			if(cardEntered.GetCardValue() != 1)
			{
				//Debug.Log("Numero Sbagliato..");
				cardEntered.ReplaceCard();
			}
			else
			{
				pile.Add(cardEntered);
				cardEntered.AnchorPoint = transform.position;
				//Debug.Log(cardEntered.AnchorPoint);
				cardEntered.ReplaceCard();
			}
		}
		else
		{
			int lastCardPlaced = pile[pile.Count - 1].GetCardValue();
			if(cardEntered.GetCardValue() == lastCardPlaced + 1 && suits == cardEntered.GetCardSuits())
			{
				cardEntered.AnchorPoint = pile[pile.Count -1].transform.position + new Vector3(0f, 0f, -GameManager.depthPadding);
				pile.Add(cardEntered);
				Debug.Log(cardEntered.AnchorPoint);
				cardEntered.ReplaceCard();
			}
		}
		//Debug.Log("Assegno null alla carta entrata");
		cardEntered = null;
	}
}
