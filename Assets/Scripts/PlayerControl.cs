using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public bool facingRight = false;			// For determining which way the player is currently facing.
	public float moveForce = 30f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 200f;				// The fastest the player can travel in the x axis.
	public Animator anim;
	GameObject carried;
	bool carrying = false;
	//public GameObject arrowModel;
	//public GameObject boss;
	//int health = 100;
	//public GameObject lost;
	//public AudioClip loseClip;
	//public AudioClip damageClip;
	//public AudioClip shoot;


	// Use this for initialization
	void Start () {
	//	lost.SetActive(false);
		//anim = this.GetComponent(Animator);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(networkView.isMine){
			// Cache the horizontal input.
			float h = Input.GetAxis("Horizontal");

			// The Speed animator parameter is set to the absolute value of the horizontal input.
			anim.SetFloat("Speed", Mathf.Abs(h));

			// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
			if(h * rigidbody2D.velocity.x < maxSpeed)
				// ... add a force to the player.
				rigidbody2D.AddForce(Vector2.right * h * moveForce);
			
			// If the player's horizontal velocity is greater than the maxSpeed...
			if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
				// ... set the player's velocity to the maxSpeed in the x axis.
				rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

			// Cache the horizontal input.
			float v = Input.GetAxis("Vertical");
			
			// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
			if(v * rigidbody2D.velocity.y < maxSpeed)
				// ... add a force to the player.
				rigidbody2D.AddForce(Vector2.up * v * moveForce);
			
			// If the player's horizontal velocity is greater than the maxSpeed...
			if(Mathf.Abs(rigidbody2D.velocity.y) > maxSpeed)
				// ... set the player's velocity to the maxSpeed in the x axis.
				rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.y) * maxSpeed, rigidbody2D.velocity.x);


			// If the input is moving the player right and the player is facing left...
			if(h > 0 && !facingRight)
				// ... flip the player.
				Flip();
			// Otherwise if the input is moving the player left and the player is facing right...
			else if(h < 0 && facingRight)
				// ... flip the player.
				Flip();

			if(carrying){
				carried.transform.position = transform.position;
			}
		}else {
			this.enabled = false;
		}
	}


	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}



	void OnCollisionEnter2D (Collision2D col)
	{
		// If the colliding gameobject is an Enemy...


	}

	void OnTriggerEnter2D (Collider2D col)
	{
		// If the colliding gameobject is safe...
		if(col.gameObject.tag == "Safe"){
			//Debug.Log("Kitten Saved!");
			if(carrying){
				carried.GetComponent<SpriteRenderer>().enabled = false;
				carried.SetActive(false);
				carrying = false;
				this.gameObject.GetComponent<Score>().savedKitten();
			}
		}

		if(col.gameObject.tag == "Kitten" && !carrying){
			//if (Input.GetButtonDown("Fire1")) {
			carrying = true;
			carried = col.gameObject;
			//}
		}
		
	}
		


}
