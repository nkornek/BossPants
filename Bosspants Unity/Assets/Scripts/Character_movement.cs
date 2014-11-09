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
			if (!jumping & !running)
			{
				gameObject.GetComponentInChildren<Animator>().SetTrigger("Running");
				running = true;
			}
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector2.right * moveSpeed * Time.deltaTime, Space.Self);
			ControlSpeed();
			if (!jumping & !running)
			{
				gameObject.GetComponentInChildren<Animator>().SetTrigger("Running");
				running = true;
			}
		}
		if (Input.GetKey(KeyCode.A))
		{
			if (!jumping)
			{
				jumping = true;
				gameObject.GetComponentInChildren<Animator>().SetTrigger("Jump");
			}
			rigidbody2D.AddForce(Vector2.up * jumpForce);
			ControlJump();
		}

		//reset the speed
		if (!Input.GetKey(KeyCode.LeftArrow) & !Input.GetKey(KeyCode.RightArrow))
		{
			if (running)
			{		
				running = false;
				gameObject.GetComponentInChildren<Animator>().SetTrigger("Run Stop");
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
			jumping = false;
			jumpForce = maxJumpForce;
			gameObject.GetComponentInChildren<Animator>().SetTrigger("JumpEnd");
		}
	}
}
