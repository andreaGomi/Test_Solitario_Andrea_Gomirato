using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableauBehaviour : MonoBehaviour
{
	bool occupied;

	private void Start()
	{
		occupied = true;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (occupied)
			return;

		CardBehaviour enteringCard = collision.GetComponent<CardBehaviour>();
		if (enteringCard.GetCardValue() != 13)
			return;

		occupied = true;
		enteringCard.AnchorPoint = transform.position;
		enteringCard.Zone = TableZone.Tableau;
		enteringCard.ReplaceCard();
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		occupied = false;
	}
}
