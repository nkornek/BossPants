using UnityEngine;
using System.Collections;

public class Character_movement : MonoBehaviour {
	public float minSpeed, maxSpeed, moveSpeed, jumpForce, maxJumpForce;
	public int jumpDecay;
	public bool jumping, running;
	public GameObject[] levelPants;
	public int level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//movement
		if (!gameObject.GetComponent<Player>().kicking)
		{
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime, Space.Self);
				ControlSpeed();
				running = true;
				levelPants[level].GetComponent<Animator>().SetBool("Running", true);
				levelPants[level].GetComponent<Transform>().localScale = new Vector2(-1, 1);
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				transform.Translate(Vector2.right * moveSpeed * Time.deltaTime, Space.Self);
				ControlSpeed();
				levelPants[level].GetComponent<Animator>().SetBool("Running", true);
				running = true;
				levelPants[level].GetComponent<Transform>().localScale = new Vector2(1, 1);
			}
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			jumping = true;
			levelPants[level].GetComponent<Animator>().SetBool("Jumping", true);
			rigidbody2D.AddForce(Vector2.up * jumpForce);
		}
		if (jumping & Input.GetKey(KeyCode.A))
		{
			rigidbody2D.AddForce(Vector2.up * jumpForce);
			ControlJump();
		}

		//reset the speed
		if (!Input.GetKey(KeyCode.LeftArrow) & !Input.GetKey(KeyCode.RightArrow))
		{
			if (running)
			{		
				running = false;
				levelPants[level].GetComponent<Animator>().SetBool("Running", false);
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
		if (coll.transform.tag == "Ground" & transform.position.y > coll.transform.position.y)
		{
			jumpForce = maxJumpForce;
			if (jumping)
			{
				jumping = false;
				levelPants[level].GetComponent<Animator>().SetBool("Jumping", false);
				}
			if (level == 2)
			{
				foreach (ParticleSystem p in levelPants[level].GetComponentsInChildren<ParticleSystem>())
				{
					p.Emit(5);
				}
			}
		}
			
	}
	
}
