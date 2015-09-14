using UnityEngine;
using System.Collections;

public class Item : Card
{
	int attackMod;
	int healthMod;
	private ItemStats stats;

	public Item(){}

	public Item Init(int ID, int skin, int cost, string name, string displayText, int attackMod, int healthMod, string effects){
		this.ID = ID;
		this.skin = skin;
		this.cost = cost;
		this.cardName = name;
		this.displayText = displayText;
		this.effects = effects;
		this.stats = new ItemStats(attackMod, healthMod);
		eHandler = new EffectsHandler (effects, this);
		return this;
	}

	public ItemStats getStats()
	{
		return stats;
	}

}



