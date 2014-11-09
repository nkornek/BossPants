﻿using UnityEngine;
using System.Collections;

public class BoomDamage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.transform.tag == "Player")
		{
			//do damage things
			coll.gameObject.GetComponent<Player>().TakeDamage();
		}
	}
}
