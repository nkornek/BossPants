using UnityEngine;
using System.Collections;

public class Character_movement : MonoBehaviour {
	public float moveSpeed, jumpForce;
	public bool canJump;

	// Use this for initialization
	void Start () {
		canJump = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		//movement
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime, Space.Self);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector2.right * moveSpeed * Time.deltaTime, Space.Self);
		}
		if (Input.GetKey(KeyCode.A) & canJump)
		{
			rigidbody2D.AddForce(Vector2.up * jumpForce);
			canJump = false;
		}
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.transform.tag == "Ground")
		{
			canJump = true;
		}
	}
}
