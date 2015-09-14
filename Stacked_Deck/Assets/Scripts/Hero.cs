using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hero : MonoBehaviour
{

	public string hero;

	Deck deck;
	public Hand hand;

	public Hero(){}

	public Hero Init(IEnumerable<int> idList){
		this.deck = new Deck(idList);
		this.hand = new Hand (deck);
		return this;
	}

	void Update(){

	}
	



}

