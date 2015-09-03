using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class Deck : List<Card>
{
	CardDatabase cdb;
	public IList<int> cardIds; 

	public Deck(IEnumerable<int> idList){
		this.cardIds = new List<int>(idList);
		cdb = new CardDatabase ();
		foreach (int i in cardIds){
			this.Add(cdb.GetByID(i));
		}
	}

	public Card drawCard(){
		int cardIndex = UnityEngine.Random.Range (0, cardIds.Count);
		Card card = cdb.GetByID(cardIds[cardIndex]);
		this.RemoveAt (cardIndex);
		return card;
	}


}