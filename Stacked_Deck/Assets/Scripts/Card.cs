using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public abstract class Card : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public string cardName;
	public string displayText;
	public Texture image;

	public abstract void OnBeginDrag(PointerEventData eventData);

	public abstract void OnDrag(PointerEventData eventData);

	public abstract void OnEndDrag(PointerEventData eventData);

}