using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	Deck deck = new Deck();
	void Start () {
		CardDatabase cdb = new CardDatabase ();
		deck.AddRange (cdb.getAll());
		foreach(Card card in deck){
			print(card.cardName);
		}
	}
}

