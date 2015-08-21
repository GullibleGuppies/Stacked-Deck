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
	public Champion(string name, string displayText, float maxHealth){
		this.cardName = name;
		this.displayText = displayText;
		this.maxHealth = maxHealth;
		this.health = this.maxHealth;
	}
}

