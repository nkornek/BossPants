using UnityEngine;
using System.Collections;

public class Character_movement : MonoBehaviour {
	public float minspeed, maxSpeed, moveSpeed, jumpForce;
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
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(Vector2.right * moveSpeed * Time.deltaTime, Space.Self);
		}
		if (Input.GetKey(KeyCode.A))
		{
			rigidbody2D.AddForce(Vector2.up * jumpForce);
			jumping = true;
		}
	
	}

	void ControlSpeed() {
		if (moveSpeed < maxSpeed)
		{
			moveSpeed += maxSpeed/30;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.transform.tag == "Ground")
		{
			jumping = false;
		}
	}
}
