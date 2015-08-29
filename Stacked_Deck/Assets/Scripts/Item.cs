using UnityEngine;
using System.Collections;

public class Item : Card
{
	private ItemStats stats;
	public Item(int ID, int skin, int cost, string name, string displayText, int attackMod, int healthMod, string effects){
		this.ID = ID;
		this.skin = skin;
		this.cost = cost;
		this.cardName = name;
		this.displayText = displayText;
		this.effects = toList<string>(effects.Split(','));
		this.stats = new ItemStats(attackMod, healthMod);
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

	public ItemStats getStats()
	{
		return stats;
	}

}



