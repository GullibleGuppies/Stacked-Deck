using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {
	
	int[] tempdeck = new int[]{1,2,3,4,1,2,3,4,1,2,3,4,1,2,3,4,1,2,3,4,1,2,3,4,1,2,3,4};
	public Hero player;

	void Start () {
		GameObject player1 = Instantiate (Resources.Load ("Prefabs/Player")) as GameObject;
		player = player1.AddComponent<Hero> () as Hero;
		player.Init (tempdeck);
		InvokeRepeating ("test", 0, 1);
	}

	void Update() {
	}

	void test(){
		player.hand.DrawCards (1);
	}
}

