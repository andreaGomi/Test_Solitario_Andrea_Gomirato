using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardBehaviour : MonoBehaviour
{
	[SerializeField] CardSO cardSO;

	public int GetCardValue()
	{
		return cardSO.value;
	}

	public CardColor GetCardColor()
	{
		return cardSO.color;
	}

	public CardSuits GetCardSuit()
	{
		return cardSO.suit;
	}

	public void AttachVertically(RectTransform newParent)
	{
		RectTransform thisTrans = GetComponent<RectTransform>();
		thisTrans.localPosition = new Vector3(0f, -GameManager.verticalPadding, 0f);
	}

	public void AttachHorizontally(RectTransform newParent)
	{
		RectTransform thisTrans = GetComponent<RectTransform>();
		thisTrans.localPosition = new Vector3(GameManager.horizontalPadding, 0f, 0f);
	}
}
