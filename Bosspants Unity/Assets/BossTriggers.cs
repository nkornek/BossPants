using UnityEngine;
using System.Collections;

public class BossTriggers : MonoBehaviour {
	public bool canBeHurt;
	public GameObject playerObject;
	public float JumpHeight, movespeed;
	public bool moveRight;


	void Start()
	{

	}

	void Update ()
	{
	}

	public void StartBattle()
	{
		canBeHurt = true;
		JumpAround ();
	}

	void JumpAround ()
	{

	}

}
