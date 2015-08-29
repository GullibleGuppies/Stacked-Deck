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
	
	string conn;
	IDbConnection dbconn;
	IDbCommand dbcmd;
	string sqlQuery;
	IDataReader reader; 

	public CardDatabase(){
	
	}

	void openConnection(){
		conn = "URI=file:" + Application.dataPath + "/cardDatabase.s3db"; //Path to database.
		dbconn = (IDbConnection) new SqliteConnection(conn);
		dbconn.Open(); //Open connection to the database.
		dbcmd = dbconn.CreateCommand();
	}

	void closeConnection(){
		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbconn.Close();
		dbconn = null;
	}

	public List<Card> getAll()
	{
		List<Card> cards = new List<Card>();
		openConnection ();
		dbcmd.CommandText = "SELECT * FROM Cards";
		reader = dbcmd.ExecuteReader();
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
			case 0:
				int entityType = reader.GetInt32(7);
				int attack = reader.GetInt32(8);
				int maxHealth = reader.GetInt32(9);
				cards.Add(new Entity(ID, skin, cost, entityType, name, displayText, attack, maxHealth, effects));
				break;
			case 1:
				int attackMod = reader.GetInt32(10);
				int healthMod = reader.GetInt32(11);
				cards.Add(new Item(ID, skin, cost, name, displayText, attackMod, healthMod, effects));
				break;
			case 2:
				cards.Add(new Spell(ID, skin, cost, name, displayText, effects));
				break;
			}

		}
		closeConnection ();
		return cards;
	}



	void getValue()
	{
		openConnection ();
		//do the shit
		closeConnection ();
	}
}

