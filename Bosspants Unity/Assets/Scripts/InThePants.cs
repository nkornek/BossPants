using UnityEngine;
using System.Collections;

public class InThePants : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LevelInThePants ()
	{
		gameObject.GetComponentInParent <Player> ().LevelUp ();
	}
}
