using UnityEngine;
using System.Collections;

public class Item : Card
{
	int attackMod;
	int healthMod;

	public Item(int ID,string name,string displayText,int attackMod,int healthMod,string effects){
	
	
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

