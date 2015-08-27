using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Data;
using Mono.Data.Sqlite;

public class CardDatabase
{
	public const string ENTITIES_DB = "Entities";
	public const string SPELLS_DB = "Spells";
	public const string ITEMS_DB = "Items";

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

	public List<Card> getAll(string db)
	{
		List<Card> cards = new List<Card>();
		openConnection ();
		switch (db) {
		case "Entities":
			sqlQuery = "SELECT ID,type,name,description,attack,maxHealth,effects FROM Entities";
			break;
		case "Items":
				sqlQuery = "SELECT ID,name,description,attackMod,healthMod,effects FROM Items";
			break;
		case "Spells":
			sqlQuery = "SELECT ID,name,description,effects FROM Spells";
			break;
		}
		dbcmd.CommandText = sqlQuery;
		reader = dbcmd.ExecuteReader();
		while (reader.Read())
		{
			switch(db){
			case "Entities":
				int ID = Convert.ToInt32(reader.GetValue(0));

				int type = Convert.ToInt32(reader.GetValue(1));

				string name;
				if (reader.IsDBNull(2)){
					name = "";
				} else {
					name = reader.GetString(2);
				}

				string displayText;
				if (reader.IsDBNull(3)){
					displayText = "";
				} else {
					displayText = reader.GetString(3);
				}

				int attack = Convert.ToInt32(reader.GetValue(4));

				int maxHealth = Convert.ToInt32(reader.GetValue(5));
			
				string effects;
				if (reader.IsDBNull(6)){
					effects = "";
				} else {
					effects = reader.GetString(6);
				}
				cards.Add(new Entity(ID,type,name,displayText,attack,maxHealth,effects));
				
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

