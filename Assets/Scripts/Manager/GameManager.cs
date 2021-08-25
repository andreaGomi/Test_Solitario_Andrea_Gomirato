using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
	[Header("Table")]
	[SerializeField] Transform deckPosition;
	[SerializeField] Transform tableau;

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
	public static float depthPadding = .01f;

	public static GameManager Instance { get; private set; } = null;

	[SerializeField] List<GameObject> deck;
	public List<GameObject> Deck { get { return deck; } }

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
		deck = new List<GameObject>();
		GenerateCards();
		ShuffleDeck();
		PlaceCards();
    }

	void Update()
	{

	}

	private void GenerateCards()
	{
		int index = 1;
		Vector3 pos = deckPosition.position;
		foreach(Material mat in clubs)
		{
			GameObject newCard = Instantiate(cardPrefab, pos, Quaternion.identity);
			newCard.name = "" + index + " Clubs";
			newCard.GetComponent<CardBehaviour>().SetCardAttributes(index, CardColor.Black, CardSuits.Clubs, TableZone.Deck, clubs[index - 1], cardBack);
			newCard.GetComponent<CardBehaviour>().SwapCardMaterial();
			deck.Add(newCard);

			pos += new Vector3(0f, 0f, -depthPadding);
			index++;
		}
		index = 1;
		foreach (Material mat in hearts)
		{
			GameObject newCard = Instantiate(cardPrefab, pos, Quaternion.identity);
			newCard.name = "" + index + " Hearts";
			newCard.GetComponent<CardBehaviour>().SetCardAttributes(index, CardColor.Red, CardSuits.Hearts, TableZone.Deck, hearts[index -1], cardBack);
			newCard.GetComponent<CardBehaviour>().SwapCardMaterial();
			deck.Add(newCard);

			pos += new Vector3(0f, 0f, -depthPadding);
			index++;
		}
		index = 1;
		foreach (Material mat in diamonds)
		{
			GameObject newCard = Instantiate(cardPrefab, pos, Quaternion.identity);
			newCard.name = "" + index + " Diamonds";
			newCard.GetComponent<CardBehaviour>().SetCardAttributes(index, CardColor.Red, CardSuits.Diamonds, TableZone.Deck, diamonds[index -1], cardBack);
			newCard.GetComponent<CardBehaviour>().SwapCardMaterial();
			deck.Add(newCard);

			pos += new Vector3(0f, 0f, -depthPadding);
			index++;
		}
		index = 1;
		foreach (Material mat in spades)
		{
			GameObject newCard = Instantiate(cardPrefab, pos, Quaternion.identity);
			newCard.name = "" + index + " Spades";
			newCard.GetComponent<CardBehaviour>().SetCardAttributes(index, CardColor.Black, CardSuits.Spades, TableZone.Deck, spades[index -1], cardBack);
			newCard.GetComponent<CardBehaviour>().SwapCardMaterial();
			deck.Add(newCard);

			pos += new Vector3(0f, 0f, -depthPadding);
			index++;
		}
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

	private void PlaceCards()
	{
		for(int i = 0; i < tableau.childCount; i++)
		{
			for(int j = 0; j <= i; j++)
			{
				CardBehaviour card = deck[i + j].GetComponent<CardBehaviour>();
				deck.Remove(card.gameObject);
				card.AnchorPoint = tableau.GetChild(i).position + new Vector3(0f, -verticalPadding * j, -depthPadding * j);
				if (j == i)
				{
					card.SwapCardMaterial();
					card.isSelectable = true;
				}
				card.ReplaceCard();
			}
		}
	}
}
