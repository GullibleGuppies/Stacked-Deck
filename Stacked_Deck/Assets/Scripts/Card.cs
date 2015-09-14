using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public abstract class Card: MonoBehaviour
{
	public int ID;
	public int skin;
	public int cost;
	public string cardName;
	public string displayText;
	public Texture image;
	public string effects;

	public int cardState = 0;

	public const int DRAW = 0;
	public const int IN_HAND = 1;
	public const int CAST = 2;
	public const int IN_PLAY = 3;
	public const int DESTROYED = 4;

	protected EffectsHandler eHandler;
	DragAndDrop dragDrop;

	void Start(){
		dragDrop = GetComponent<DragAndDrop> ();
	}

	void Update(){
		switch (cardState) {
		case DRAW:
			Draw();
			break;
		case IN_HAND:
			InHand();
			break;
		case CAST:
			OnCast();
			break;
		case IN_PLAY:
			InPlay();
			break;
		case DESTROYED:
			OnKill();
			break;
		}
	}

	public virtual void Draw(){
		eHandler.Draw ();
		cardState = IN_HAND;
	}

	public virtual void InHand(){
		eHandler.InHand ();
		if (dragDrop._mouseState == false && cardState == IN_HAND && transform.position.y >= -4) {
			cardState = CAST;
			DestroyObject(dragDrop);
		}
	}

	public virtual void OnCast(){
		eHandler.OnCast ();
		cardState = IN_PLAY;
	}

	public virtual void InPlay(){
		eHandler.InPlay ();
	}

	public virtual void OnKill(){
		eHandler.OnKill ();
	}
	

}