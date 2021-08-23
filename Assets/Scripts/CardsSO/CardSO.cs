using UnityEngine;

public enum CardColor
{
	Black,
	Red
}

public enum CardSuits
{
	Hearts,
	Diamonds,
	Clubs,
	Spades
}

[CreateAssetMenu(menuName = "Card")]
public class CardSO : ScriptableObject
{
	public int value;
	public CardColor color;
	public CardSuits suit;
}
