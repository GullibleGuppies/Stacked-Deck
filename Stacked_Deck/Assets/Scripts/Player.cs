using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Component
{
	Deck deck;
	public Hand hand;

	public Player(IEnumerable<int> idList){
		this.deck = new Deck(idList);
		this.hand = new Hand (deck);
	}


}

