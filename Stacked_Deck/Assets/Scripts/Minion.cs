using UnityEngine;
using System.Collections;

public class Minion : Card
{
	public float health;
	public float attack;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
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

