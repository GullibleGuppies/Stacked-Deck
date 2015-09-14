using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Entity : Card
{
	public const int TYPE_MONSTER = 0;
	public const int TYPE_CHAMPION = 1;

	public int maxHealth;
	public int health;
	public int attack;
	public int entityType;
	private IList<Item> itemsEquipped;
	private const int ITEM_MAX = 3;

	public Entity (){}

	public Card Init(int ID, int skin, int cost, int entityType, string name, string displayText, int attack, int maxHealth,string effects){
		this.ID = ID;
		this.skin = skin;
		this.cost = cost;
		this.entityType = entityType;
		this.cardName = name;
		this.displayText = displayText;
		this.attack = attack;
		this.maxHealth = maxHealth;
		this.effects = effects;
		this.health = this.maxHealth;
		this.health = this.maxHealth = maxHealth;
		this.itemsEquipped = new List<Item>();
		return this;
	}

	public override void OnCast ()
	{
		Game.battleField.cards.Add (this);
		base.OnCast ();
	}

	public bool tryEquipItem(Item item)
	{
		if(canEquipItem(item))
		{
			doEquipItem(item);
			return true;
		}
		return false;
	}

	private bool canEquipItem(Item item)
	{
		if(itemsEquipped.Count < ITEM_MAX)
		{
			return true;
		}
		return false;
	}

	private void doEquipItem(Item item)
	{
		itemsEquipped.Add(item);
	}

	private ItemStats getStatsFromItems()
	{
		return ItemStats.addStats(itemsEquipped);
	}
	
}

