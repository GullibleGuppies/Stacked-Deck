using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.EventSystems;
public abstract class Card: ScriptableObject, IBeginDragHandler, IDragHandler, IEndDragHandler, IEffects
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

	public abstract void OnBeginDrag(PointerEventData eventData);

	public abstract void OnDrag(PointerEventData eventData);

	public abstract void OnEndDrag(PointerEventData eventData);

	public virtual void damage(){}
}