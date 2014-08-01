using UnityEngine;
using System.Collections;

public class kitten_spawner : MonoBehaviour {
	int min;
	int max; //make spawn rate adjustable
	public GameObject kittenModel;

	// Use this for initialization
	void Start () {
		min = 1;
		max = 3;	
		StartCoroutine(spread_cats());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator spread_cats(){
		yield return new WaitForSeconds(Random.Range(min, max));
		GameObject kitten = (GameObject) Instantiate(kittenModel, new Vector3( Random.Range(1.7f, 14.7f), 0.6f, 0) , transform.rotation); //spawn the kitten on a random x value at the top of the slide
		StartCoroutine(spread_cats());
	}
}
