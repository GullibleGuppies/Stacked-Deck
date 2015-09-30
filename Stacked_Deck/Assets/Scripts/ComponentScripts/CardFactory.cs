using UnityEngine;
using System.Collections;

public static class CardFactory
{
	static GameObject cardBase = Resources.Load ("Prefabs/card") as GameObject;
	static CardDatabase cardDB = new CardDatabase();

	public static GameObject createCard(int ID){
		GameObject returnCard = cardBase;
		ArrayList cardInfo = cardDB.GetByID (ID);
		CardMetadata meta = returnCard.AddComponent<CardMetadata> ();
		meta.ID = (int)cardInfo [0];
		meta.cardCost = (int[])cardInfo [1];
		meta.name = (string)cardInfo [4];
		meta.description = (string)cardInfo [5];

		switch ((int)cardInfo[2]) {
		case 0:
			returnCard.AddComponent<CardAttack> ().baseAttack = (int)cardInfo [8];
			returnCard.AddComponent<CardHealth> ().maxHealth = (int)cardInfo[9];
			break;
		case 1:
			break;
		case 2:
			break;
		}
		returnCard.AddComponent<CardAbilities>();
		return returnCard;
	}

}

