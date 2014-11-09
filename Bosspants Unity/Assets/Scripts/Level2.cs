using UnityEngine;
using System.Collections;

public class Level2 : MonoBehaviour {

	public Player player;

	// Use this for initialization
	void Start () {
		player.GetComponent <Player> ().LevelUp();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
