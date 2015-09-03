using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour {
	
	int[] tempdeck = new int[]{0,0,0,1,1,1,2,2,2};
	public Player localPlayer;

	void Start () {
		localPlayer = new Player (tempdeck);
		localPlayer.hand.DrawCards (2);
		print (localPlayer.hand [0].cardName);
	}
}

