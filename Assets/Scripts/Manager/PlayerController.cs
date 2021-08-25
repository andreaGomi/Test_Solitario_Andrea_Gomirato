using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] LayerMask layerMask;
	private GameObject cardHelded = null;
	
    void Start()
    {
        
    }

    void Update()
    {
		ManageInput();
		//Debug.Log(cardHelded);
    }

	private void ManageInput()
	{
		if (Input.GetMouseButton(0))
		{
			Vector3 mousePosWS = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
			if (!cardHelded)
			{
				RaycastHit2D hit = Physics2D.Raycast(mousePosWS, Vector2.zero, layerMask);
				if (hit && hit.collider.CompareTag("Card")){
					cardHelded = hit.collider.gameObject;
					cardHelded.GetComponent<CardBehaviour>().IsCurrentlyHelded = true;
					cardHelded.GetComponent<SpriteRenderer>().sortingOrder = 1;
				}
			}
			else
			{
				cardHelded.transform.position = mousePosWS;
			}
		}
		else
		{
			if (!cardHelded)
				return;

			cardHelded.GetComponent<SpriteRenderer>().sortingOrder = 0;
			CardBehaviour currentCard = cardHelded.GetComponent<CardBehaviour>();
			currentCard.ReplaceCard();
			currentCard.IsCurrentlyHelded = false;
			cardHelded = null;
		}
	}
}
