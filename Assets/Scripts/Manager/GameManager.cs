using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
	[Header("Materials")]
	public Material[] hearts; 
	public Material[] diamonds; 
	public Material[] clubs; 
	public Material[] spades;
	public Material cardBack;

	[Header("Card Prefab")]
	[SerializeField] GameObject cardPrefab;

	public static float verticalPadding = .5f;
	public static float horizontalPadding = .3f;
	public static float depthPadding = .03f;

	public static GameManager Instance { get; private set; } = null;

	List<GameObject> cardsList;

	private void Awake()
	{
		if (!Instance)
		{
			Instance = FindObjectOfType<GameManager>();
			if (Instance != this)
				Destroy(this.gameObject);
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		cardsList = new List<GameObject>();
		GenerateCards();
    }

	private void GenerateCards()
	{
		int index = 0;
		Vector3 pos = Vector3.zero;
		foreach(Material mat in clubs)
		{
			GameObject newCard = Instantiate(cardPrefab, pos, Quaternion.identity);
			newCard.name = "" + (index + 1) + "Clubs";
			newCard.GetComponent<CardBehaviour>().SetCardAttributes(index + 1, CardColor.Black, CardSuits.Clubs, clubs[index], cardBack);
			newCard.GetComponent<CardBehaviour>().ApplyMaterialsChanges();

			//pos.x += horizontalPadding;
			pos.y -= verticalPadding;
			pos.z -= depthPadding;

			index++;
		}
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
