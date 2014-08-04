using UnityEngine;
using System.Collections;

public class kitten_spawner : MonoBehaviour {
	int num_players;
	int min;
	int max; //make spawn rate adjustable
	public GameObject kittenModel;
	GameObject[] g;

	// Use this for initialization
	void Start () {
		g = GameObject.FindGameObjectsWithTag("Player");
		num_players = g.Length;
		min = Mathf.Abs( 5 - num_players);
		max = Mathf.Abs( 8 - num_players);	
		StartCoroutine(spread_cats());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void alert_missed_kitten(){
		for(int i = 0; i < g.Length; i++){
			g[i].gameObject.GetComponent<Score>().kittenMissed();
		}
	}

	IEnumerator spread_cats(){
		yield return new WaitForSeconds(Random.Range(min, max));
		GameObject kitten = (GameObject) Instantiate(kittenModel, new Vector3( Random.Range(1.7f, 14.7f), 0.6f, 0) , transform.rotation); //spawn the kitten on a random x value at the top of the slide
		StartCoroutine(spread_cats());
	}
}
