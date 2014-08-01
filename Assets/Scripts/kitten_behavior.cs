using UnityEngine;
using System.Collections;

public class kitten_behavior : MonoBehaviour {
	int time_til_slide;
	public Animator anim;
	public Rigidbody2D my_body;

	// Use this for initialization
	void Start () {
		anim.SetBool("idling", true);
		time_til_slide = Random.Range(2,30);
		Debug.Log(time_til_slide);
		StartCoroutine(prepare_to_slide());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator prepare_to_slide(){
		yield return new WaitForSeconds(time_til_slide);
		Debug.Log("Sliding!");
		anim.SetBool("idling", false);
		my_body.gravityScale = Random.Range(.05f,.5f);
	}
}
