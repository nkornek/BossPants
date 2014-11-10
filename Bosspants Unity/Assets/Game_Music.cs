using UnityEngine;
using System.Collections;

public class Game_Music : MonoBehaviour {
	public AudioClip mainMusic, bossMusic;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Application.loadedLevel == 3 & gameObject.GetComponent<AudioSource>().clip != bossMusic)
		{
			gameObject.GetComponent<AudioSource>().clip = bossMusic;
			gameObject.GetComponent<AudioSource>().Play();
		}

		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	
	}
}
