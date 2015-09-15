using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {

	public static Game thisGame;
	int[] tempdeck = new int[]{1,2,3};
	public Hero player;
	public static BattleField battleField;

	public Game(){
	}

	void Start () {
		Init ();
		GameObject player1 = Instantiate (Resources.Load ("Prefabs/Player")) as GameObject;
		player = player1.AddComponent<Hero> () as Hero;
		player.Init (tempdeck);
		test ();
	}

	void Update() {
	}

	void Init(){
		thisGame = gameObject.GetComponent<Game> ();
		battleField = gameObject.AddComponent<BattleField>() as BattleField;
		print (battleField == null);
		
	}

	void test(){
		player.hand.DrawCards (3);
	}
}

