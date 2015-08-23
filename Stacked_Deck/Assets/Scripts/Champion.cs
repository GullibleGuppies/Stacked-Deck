using UnityEngine;
using System.Collections;

public class Champion : Card
{
	// stats
	public float health;
	public float maxHealth;
	public float experience = 0;
	public const float maxExperience = 3;
	public int level = 0;

	// set card values

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

