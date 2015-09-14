using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Spell : Card
{
	public Spell(){}

	public Spell Init(int ID, int skin, int cost, string name, string displayText, string effects){
		this.ID = ID;
		this.cardName = name;
		this.displayText = displayText;
		this.effects = effects;
		return this;
	}
}

