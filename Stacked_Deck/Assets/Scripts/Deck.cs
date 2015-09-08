using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class Deck : List<int>
{
	CardDatabase cdb;

	public Deck(IEnumerable<int> idList){
		this.AddRange (idList);
		cdb = new CardDatabase ();
	}

	public Card drawCard(){
		int cardIndex = UnityEngine.Random.Range (0, this.Count);
		Card card = cdb.GetByID(this[cardIndex]);
		this.Remove(this[cardIndex]);
		return card;
	}


}