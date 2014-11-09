using UnityEngine;
using System.Collections;

public class Character_movement : MonoBehaviour {
	public float minSpeed, maxSpeed, moveSpeed, jumpForce, maxJumpForce;
	public int jumpDecay;
	public bool jumping, running;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//movement
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime, Space.Self);
			ControlSpeed();
			running = true;
			gameObject.GetComponentInChildren<Animator>().SetBool("Running", true);
			gameObject.GetComponentInChildren<Transform>().localScale = new Vector2(-1, 1);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector2.right * moveSpeed * Time.deltaTime, Space.Self);
			ControlSpeed();
			gameObject.GetComponentInChildren<Animator>().SetBool("Running", true);
			running = true;
			gameObject.GetComponentInChildren<Transform>().localScale = new Vector2(1, 1);
		}
		if (Input.GetKey(KeyCode.A))
		{
			jumping = true;
			gameObject.GetComponentInChildren<Animator>().SetBool("Jumping", true);
			rigidbody2D.AddForce(Vector2.up * jumpForce);
			ControlJump();
		}

		//reset the speed
		if (!Input.GetKey(KeyCode.LeftArrow) & !Input.GetKey(KeyCode.RightArrow))
		{
			if (running)
			{		
				running = false;
				gameObject.GetComponentInChildren<Animator>().SetBool("Running", false);
			}
			moveSpeed = minSpeed;
		}
	
	}

	void ControlSpeed() {
		if (moveSpeed < maxSpeed)
		{
			moveSpeed += (maxSpeed - minSpeed)/60;
		}
	}

	void ControlJump() {
		if (jumpForce > 0)
		jumpForce -= maxJumpForce / jumpDecay;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.transform.tag == "Ground")
		{
			jumpForce = maxJumpForce;
			if (jumping)
			{
				jumping = false;
				gameObject.GetComponentInChildren<Animator>().SetBool("Jumping", false);
			}
		}
	}
}
