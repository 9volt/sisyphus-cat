using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Score : MonoBehaviour {
	int kittens_saved;
	int kittens_missed;
	int player_joined_num;

	// Use this for initialization
	void Start () {
		kittens_saved = 0;
		kittens_missed = 0; 
		player_joined_num = 1; //change later
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI (){
		GUI.Label (new Rect(20 + ((player_joined_num -1) * 100),Screen.height - 40, 100, 70), 
		           " Player " + player_joined_num +":   " + (kittens_saved - kittens_missed)); //varaible x so players scores are not stacked on top of each other.

		//GUI.Label (new Rect(20,Screen.height - 40, 400, 70),
		//         "Player 1 has saved " + (kittens_saved) + " kittens!  " + (kittens_missed) + " kittens have been missed.");
	}

	public void savedKitten(){
		kittens_saved++;
	}

	public void kittenMissed(){
		kittens_missed++;
	}
}
