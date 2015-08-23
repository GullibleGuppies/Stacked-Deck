using UnityEngine;
using System.Collections;

public abstract class Item : Card
{
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

