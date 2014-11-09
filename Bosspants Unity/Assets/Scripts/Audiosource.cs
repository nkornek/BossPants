using UnityEngine;
using System.Collections;

public class Audiosource : MonoBehaviour {

	public AudioSource listentome;

	public AudioClip [] clips;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void BIGLANDING ()
	{
		listentome.clip = clips [0];
		listentome.Play ();
	}
	public void DifStepSounds ()
	{
		listentome.clip = clips [2];
		listentome.Play ();
	}

	public void steps ()
	{
		listentome.clip = clips [4];
		listentome.Play ();
	}

	public void normalLanding ()
	{
		listentome.clip = clips [3];
		listentome.Play ();
	}
	public void MEGAPHONE ()
	{
		listentome.clip = clips [12];
		listentome.Play ();
	}

	public void GetInsideThePants ()
	{
		listentome.clip = clips [13];
		listentome.Play ();
	}

}
