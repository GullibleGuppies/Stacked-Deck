using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;

public abstract class Card: MonoBehaviour, IEffects
{
	public int ID;
	public int skin;
	public int cost;
	public string cardName;
	public string displayText;
	public Texture image;
	public List<string> effects;

	protected List<T> toList<T>(IList<T> enu){
		return enu.ToList ();
	}

	public virtual void OnMouseOver(){
		Debug.Log ("EY SHA BOI");
	}

	public virtual void dealDamage(int damage, Entity target){}

	public virtual void takeDamage(int damage){}
	
}