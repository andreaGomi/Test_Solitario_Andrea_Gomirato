using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoundationBehaviour : MonoBehaviour
{

	private bool isOccupied;

    // Start is called before the first frame update
    void Start()
    {
		isOccupied = false;
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		
	}

	

	// Update is called once per frame
	void Update()
    {
        
    }
}
