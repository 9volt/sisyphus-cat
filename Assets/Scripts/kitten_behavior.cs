using UnityEngine;
using System.Collections;

public class kitten_behavior : MonoBehaviour {
	int time_til_slide;
	public Animator anim;
	public Rigidbody2D my_body;
	public bool grabbed;
	float grav;
	kitten_spawner ks;

	// Use this for initialization
	void Start () {
		anim.SetBool("idling", true);
		grabbed = false;
		time_til_slide = Random.Range(1,10);
		ks = GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<kitten_spawner>();
		//Debug.Log(time_til_slide);
		gameObject.GetComponent<BoxCollider2D>().enabled = false;
		StartCoroutine(prepare_to_slide());
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator prepare_to_slide(){
		yield return new WaitForSeconds(time_til_slide);
		//Debug.Log("Sliding!");
		anim.SetBool("idling", false);
		grav = Random.Range(.05f,.5f);
		my_body.gravityScale = grav;
		gameObject.GetComponent<BoxCollider2D>().enabled = true;
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		// If the colliding gameobject is bad...
		if(col.gameObject.tag == "Bad"){
			//Debug.Log("Kitten Missed!");

			ks.alert_missed_kitten();
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			gameObject.SetActive(false);
			//AudioSource.PlayClipAtPoint(boss_damage1, transform.position);
		}

		//if(col.gameObject.tag == "player"){
		//	Debug.Log("Kitten Grabbed!");
		//	//damage player
		//	holder = col.gameObject;
		//	my_body.gravityScale = 0;
			//gameObject.SetActive(false);
			//AudioSource.PlayClipAtPoint(boss_damage1, transform.position);
		//}

	}

}
