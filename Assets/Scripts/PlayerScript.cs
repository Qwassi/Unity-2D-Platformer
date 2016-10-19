using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{

	public float MaxSpeed;
	private Animator playerAnimator;
	private Rigidbody2D playerRigidBody2D;
	private bool isFacingRight;

	// Use this for initialization
	void Start ()
	{
	
		playerRigidBody2D = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<Animator> ();
		isFacingRight = true;
	}

	//FixedUpdate is called at a fixed amount of time
	//It is best suited for physics-based game objects
	void FixedUpdate ()
	{
		float movement = Input.GetAxis ("Horizontal");
		playerAnimator.SetFloat("Speed", Mathf.Abs(movement));
		playerRigidBody2D.velocity = new Vector2 (movement * MaxSpeed, playerRigidBody2D.velocity.y);

		//Flip the character horizontally 
		if (movement > 0 && !isFacingRight) {
			FlipCharacter ();
		} else if (movement < 0 && isFacingRight) {
			FlipCharacter ();
		}
//		if(movement != 0)
//			playerAnimator.SetFloat("Speed", Mathf.Abs(movement));
//		else
//			playerAnimator.SetFloat("Speed", Mathf.Abs(movement));


	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void FlipCharacter ()
	{
		isFacingRight = !isFacingRight;
		Vector3 characterScale = this.transform.localScale;
		characterScale.x *= -1;
		transform.localScale = characterScale;
	}
}
