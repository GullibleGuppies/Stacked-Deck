using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Spell : Card
{
	public Spell(int ID, int skin, int cost, string name, string displayText, string effects){
		this.ID = ID;
		this.cardName = name;
		this.displayText = displayText;
		this.effects = toList<string>(effects.Split(','));
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

