using UnityEngine;
using System.Collections;

public class Character_movement : MonoBehaviour {
	public float minSpeed, maxSpeed, moveSpeed, jumpForce, maxJumpForce;
	public int jumpDecay;
	public bool jumping;


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
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector2.right * moveSpeed * Time.deltaTime, Space.Self);
			ControlSpeed();
		}
		if (Input.GetKey(KeyCode.A))
		{
			rigidbody2D.AddForce(Vector2.up * jumpForce);
			jumping = true;
			ControlJump();
		}

		//reset the speed
		if (!Input.GetKey(KeyCode.LeftArrow) & !Input.GetKey(KeyCode.RightArrow))
		{
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
		}
	}
}
