using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine;

public class CardDatabase
{
	public const int ENTITIES = 0;
	public const int ITEMS = 1;
	public const int SPELLS = 2;

	GameObject cardPrefab;
	
	string conn;
	IDbConnection dbconn;
	IDbCommand dbcmd;
	string sqlQuery;
	IDataReader reader; 

	public CardDatabase(){
		cardPrefab = Resources.Load ("Prefabs/card") as GameObject;
	}

	void openConnection(){
		conn = "URI=file:" + Application.dataPath + "/cardDatabase.s3db"; //Path to database.
		dbconn = (IDbConnection) new SqliteConnection(conn);
		dbconn.Open(); //Open connection to the database.
		dbcmd = dbconn.CreateCommand();
	}

	Card getInfo(){
		Card card = null;
		while (reader.Read())
		{
			int ID = reader.GetInt32(0);
			int cost = reader.GetInt32(1);
			int cardType = reader.GetInt32(2);
			int skin = reader.GetInt32(3);
			string name = reader.GetString(4);
			string displayText = reader.GetString(5);
			string effects = reader.GetString(6);
			switch(cardType){
			case ENTITIES:
				int entityType = reader.GetInt32(7);
				int attack = reader.GetInt32(8);
				int maxHealth = reader.GetInt32(9);
				GameObject entity = GameObject.Instantiate(cardPrefab);
				entity.name = "Entity" + ID.ToString();
				Entity eComp = entity.AddComponent<Entity>() as Entity;
				card = eComp.Init(ID, skin, cost, entityType, name, displayText, attack, maxHealth, effects);
				break;
			case ITEMS:
				int attackMod = reader.GetInt32(10);
				int healthMod = reader.GetInt32(11);
				GameObject item = GameObject.Instantiate(cardPrefab);
				item.name = "Item" + ID.ToString();
				Item iComp = item.AddComponent<Item>() as Item;
				card = iComp.Init(ID, skin, cost, name, displayText, attackMod, healthMod, effects);
				break;
			case SPELLS:
				GameObject spell = GameObject.Instantiate(cardPrefab);
				spell.name = "Spell" + ID.ToString();
				Spell sComp = spell.AddComponent<Spell>() as Spell;
				card = sComp.Init(ID, skin, cost, name, displayText, effects);
				break;
			}			
		}
		return card;
		
	}

	void closeConnection(){
		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbconn.Close();
		dbconn = null;
	}
	
	public Card GetByID(int id)
	{
		openConnection ();
		dbcmd.CommandText = "SELECT * FROM Cards WHERE ID=" + Convert.ToString(id);
		reader = dbcmd.ExecuteReader();
		Card card = getInfo ();
		closeConnection ();
		return card;
	}
}

