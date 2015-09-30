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

	ArrayList getInfo(){
		ArrayList cardInfoArray = null;
		while (reader.Read())
		{
			for (int i = 0; i < reader.FieldCount; i++)
				cardInfoArray.Add(reader.GetValue(i)); 
		}
		return cardInfoArray;
		
	}

	void closeConnection(){
		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbconn.Close();
		dbconn = null;
	}
	
	public ArrayList GetByID(int id)
	{
		openConnection ();
		dbcmd.CommandText = "SELECT * FROM Cards WHERE ID=" + Convert.ToString(id);
		reader = dbcmd.ExecuteReader();
		ArrayList cardInfo = getInfo ();
		closeConnection ();
		return cardInfo;
	}
}

