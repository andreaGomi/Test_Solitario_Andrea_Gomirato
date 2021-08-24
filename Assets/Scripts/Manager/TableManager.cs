using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableManager : MonoBehaviour
{

	[SerializeField] RectTransform tableau;
	[SerializeField] RectTransform pile;
	[SerializeField] RectTransform foundation;

	private CardBehaviour cardHelded = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		ManageInput();
    }

	private void ManageInput()
	{
		if (Input.GetMouseButton(0))
		{
			if (!cardHelded)
			{
				//Vector3 mousePosWS = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y)); 
				Vector3 mousePosWS = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
				RaycastHit2D hit = Physics2D.Raycast(mousePosWS, Vector2.zero);

				if(hit)
				{
					Debug.Log("Hit: " + hit.collider.tag);
				}
				else
				{
					Debug.Log("No Hit");
				}
			}
		}
		else if (cardHelded)
		{
			cardHelded = null;
		}
	}
}
