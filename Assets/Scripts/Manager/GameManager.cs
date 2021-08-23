using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static int verticalPadding = 31;
	public static int horizontalPadding = 31;

	public static GameManager instance = null;

	private void Awake()
	{
		if (!instance && !(instance = FindObjectOfType<GameManager>()))
		{
			instance = this;
		}
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
