using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float triggerDistance;
	public int peoplePantsed, peopleToPants;
	public float chargeTime, chargeTotal;

	// Use this for initialization
	void Start () {
		chargeTime = chargeTotal;
	}
	
	// Update is called once per frame
	void Update () {
	//trigger nearby peeps
		if (Input.GetKey(KeyCode.Space))
		{
			CallPeople();
		}
	//kick!
		if (Input.GetKey(KeyCode.S))
		{
			chargeTime -= Time.deltaTime;
		}
		if (Input.GetKeyUp(KeyCode.S))
		{
			if (chargeTime <= 0)
			{
				//bicycle kick
			}
			else
			{
				//regular kick
			}
			chargeTime = chargeTotal;
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
			if (Mathf.Abs (Vector2.Distance(person.transform.position, transform.position)) < triggerDistance && person.GetComponent <Person>().triggered == false)
			{
				//trigger some speech bubblin
				person.GetComponent <Person>().triggered = true;
			}
		}
	}

}
