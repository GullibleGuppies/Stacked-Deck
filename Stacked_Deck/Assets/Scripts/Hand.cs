using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Hand : List<Card>
{
	Deck deck;

	public Hand(Deck deck){
		this.deck = deck;
	}

	public void DrawCards(int cardsToDraw){
		for (int i = 0; i < cardsToDraw; i++)
			this.Add (deck.drawCard());
	}
}

