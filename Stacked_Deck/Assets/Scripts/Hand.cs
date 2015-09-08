using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Hand : List<Card>
{
	Deck deck;

	public Hand(Deck deck){
		this.deck = deck;
	}

	public bool DrawCards(int cardsToDraw){
		if (deck.Count > 0) {
			for (int i = 0; i < cardsToDraw; i++)
				this.Add (deck.drawCard ());
			FanCards();
			return true;
		}
		return false;
	}

	public void FanCards(){
		int i = 0;
		Vector3 handPos = new Vector3 (0, -6, 1);
		Vector3 cardEulerRot = new Vector3 (90, -5, 0);
		float cardCount = (float) this.Count;
		float radius = 30f;
		Vector3 rotPoint = new Vector3(0,-radius,0);
		float arcSpacing =(5f/Mathf.Pow((cardCount+1),0.5f));
		float initialArcPos= (this.Count * arcSpacing)/2;
		foreach (Card card in this) {
			i++;
			Transform t = card.transform;
			Vector3 cardPos = t.position;
			Quaternion cardRot = t.rotation;
			cardPos = handPos;
			cardRot.eulerAngles = cardEulerRot;
			t.position = cardPos;
			t.rotation = cardRot;
			float arcLength = Mathf.Lerp(initialArcPos, -initialArcPos, i / (cardCount+1));
			float arcAngle = Mathf.Rad2Deg * (arcLength/radius);
			t.RotateAround(rotPoint, Vector3.back, arcAngle);
		}
	}
}

