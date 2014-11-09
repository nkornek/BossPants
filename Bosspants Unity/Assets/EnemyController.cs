using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	public GameObject LeftBound, RightBound;
	public Vector2 LeftBarrier, RightBarrier;
	public float moveSpeed;
	public bool moveRight, canMove;
	public float timeToAttack, timeBetweenAttacks;

	public GameObject shot;

	// Use this for initialization
	void Start () {
		LeftBarrier = LeftBound.transform.position;
		RightBarrier = RightBound.transform.position;
		Destroy (LeftBound);
		Destroy (RightBound);
		timeToAttack = timeBetweenAttacks;
		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {
		//movement
		if (moveRight & canMove)
		{
			transform.localScale = new Vector2 (-1, 1);
			if (transform.position.x < RightBarrier.x)
			{
				transform.Translate(Vector2.right * moveSpeed * Time.deltaTime, Space.Self);
			}
			if (transform.position.x >= RightBarrier.x)
			{
				moveRight = false;
			}
		}
		else if (!moveRight & canMove)
		{
			transform.localScale = new Vector2 (1, 1);
			if (transform.position.x > LeftBarrier.x)
			{
				transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime, Space.Self);
			}
			if (transform.position.x <= LeftBarrier.x)
			{
				moveRight = true;
			}
		}
		//attack
		timeToAttack -= Time.deltaTime;
		if (timeToAttack <= 0 & canMove)
		{
			canMove = false;
			gameObject.GetComponent<Animator>().SetBool("CanMove", false);
			Invoke ("FireShot", 1);
		}
	}

	void FireShot()
	{
		shot.SetActive (true);
		Invoke ("ShotOver", 0.05f);
	}

	void ShotOver()
	{
		shot.SetActive (false);
		canMove = true;
		gameObject.GetComponent<Animator>().SetBool("CanMove", true);
		timeToAttack = timeBetweenAttacks;
	}

	public void Explode()
	{
		gameObject.GetComponentInChildren<ParticleSystem> ().Emit (30);
		Destroy (gameObject);
	}
}
