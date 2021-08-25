using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
	[Header("Table")]
	[SerializeField] Transform DeckPosition;

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

	[SerializeField] private GameObject[] deck;
	public GameObject[] Deck { get { return deck; } }

	private void Awake()
	{
		if (!Instance)
		{
			Instance = FindObjectOfType<GameManager>();
			if (Instance != this)
				Destroy(this.gameObject);
		}
	}
	
	void Start()
    {
		deck = new GameObject[52];
		GenerateCards();
		ShuffleDeck();
    }

	void Update()
	{

	}

	private void ShuffleDeck()
	{
		System.Random rdm = new System.Random();
		for(int i = 0; i < 52; i++)
		{
			int n = i + rdm.Next(52 - i);
			
			Vector3 tmp = deck[i].transform.position;
			deck[i].transform.position = deck[n].transform.position;
			deck[i].GetComponent<CardBehaviour>().AnchorPoint = deck[n].transform.position;
			deck[n].transform.position = tmp;
			deck[n].GetComponent<CardBehaviour>().AnchorPoint = tmp;
		}
	}

	private void GenerateCards()
	{
		int index = 0;
		Vector3 pos = new Vector3(-1.5f, 0f, -depthPadding);
		foreach(Material mat in clubs)
		{
			GameObject newCard = Instantiate(cardPrefab, pos, Quaternion.identity);
			newCard.name = "" + ((index % 13) + 1) + " Clubs";
			newCard.GetComponent<CardBehaviour>().SetCardAttributes((index % 13) + 1, CardColor.Black, CardSuits.Clubs, clubs[(index % 13)], cardBack);
			newCard.GetComponent<CardBehaviour>().SwapCardMaterial();
			deck[index] = newCard;

			pos.y -= verticalPadding;
			pos.z -= depthPadding;

			index++;
		}
		pos.x += 1.5f;
		pos.y = 0f;
		pos.z = 0f;
		foreach (Material mat in hearts)
		{
			GameObject newCard = Instantiate(cardPrefab, pos, Quaternion.identity);
			newCard.name = "" + ((index % 13) + 1) + " Hearts";
			newCard.GetComponent<CardBehaviour>().SetCardAttributes((index % 13) + 1, CardColor.Red, CardSuits.Hearts, hearts[(index % 13)], cardBack);
			newCard.GetComponent<CardBehaviour>().SwapCardMaterial();
			deck[index] = newCard;

			pos.y -= verticalPadding;
			pos.z -= depthPadding;

			index++;
		}
		pos.x += 1.5f;
		pos.y = 0f;
		pos.z = 0f;
		foreach (Material mat in diamonds)
		{
			GameObject newCard = Instantiate(cardPrefab, pos, Quaternion.identity);
			newCard.name = "" + ((index % 13) + 1) + " Diamonds";
			newCard.GetComponent<CardBehaviour>().SetCardAttributes((index % 13) + 1, CardColor.Red, CardSuits.Diamonds, diamonds[(index % 13)], cardBack);
			newCard.GetComponent<CardBehaviour>().SwapCardMaterial();
			deck[index] = newCard;

			pos.y -= verticalPadding;
			pos.z -= depthPadding;

			index++;
		}
		pos.x += 1.5f;
		pos.y = 0f;
		pos.z = 0f;
		foreach (Material mat in spades)
		{
			GameObject newCard = Instantiate(cardPrefab, pos, Quaternion.identity);
			newCard.name = "" + ((index % 13) + 1) + " Spades";
			newCard.GetComponent<CardBehaviour>().SetCardAttributes((index % 13) + 1, CardColor.Black, CardSuits.Spades, spades[(index % 13)], cardBack);
			newCard.GetComponent<CardBehaviour>().SwapCardMaterial();
			deck[index] = newCard;

			//pos.x += horizontalPadding;
			pos.y -= verticalPadding;
			pos.z -= depthPadding;

			index++;
		}
	}
}
