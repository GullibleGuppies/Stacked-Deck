using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(BattleField))]

public class Game : MonoBehaviour {
	
	int[] tempdeck = new int[]{4};
	public Hero player;
	public static BattleField battleField;

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
		battleField = GetComponent (typeof(BattleField)) as BattleField;
	}

	void test(){
		player.hand.DrawCards (1);
	}
}

