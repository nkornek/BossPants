using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float triggerDistance;
	public int peoplePantsed, peopleToPants;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.Space))
		{
			CallPeople();
		}
	}

	public void addPerson ()
	{
		peoplePantsed++;
	
	}

	public void CallPeople() 
	{
		foreach (GameObject person in GameObject.FindGameObjectsWithTag("person"))
		{
			if (Mathf.Abs (Vector2.Distance(person.transform.position, transform.position)) < triggerDistance)
			{
				//trigger some speech bubblin
				person.GetComponent <Person>().triggered = true;
			}
		}
	}

}
