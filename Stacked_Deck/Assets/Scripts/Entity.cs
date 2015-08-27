using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Entity : Card
{
	public const int MONSTER = 0;
	public const int CHAMPION = 1;

	public int maxHealth;
	public int health;
	public int attack;
	public int type;	

	public Entity(int ID, int type, string name, string displayText, int attack, int maxHealth,string effects){
		this.ID = ID;
		this.type = type;
		this.attack = attack;
		this.cardName = name;
		this.displayText = displayText;
		this.maxHealth = maxHealth;
		this.health = this.maxHealth;
		this.health = this.maxHealth = maxHealth;
	}
	
	public override void OnBeginDrag (UnityEngine.EventSystems.PointerEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	public override void OnDrag (UnityEngine.EventSystems.PointerEventData eventData)
	{
		throw new System.NotImplementedException ();
	}

	public override void OnEndDrag (UnityEngine.EventSystems.PointerEventData eventData)
	{
		throw new System.NotImplementedException ();
	}
}

