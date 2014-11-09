using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float triggerDistance;
	public int peoplePantsed, peopleToPants;
	public float chargeTime, chargeTotal;
	public GameObject[] levelPants;
	public int level;

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
		//for debug, will remove later
		if (Input.GetKeyDown(KeyCode.F))
		{
			LevelUp();
		}
	//kick!
		if (level == 2)
		{
			if (Input.GetKey(KeyCode.S))
			{
				chargeTime -= Time.deltaTime;
			}
			if (Input.GetKeyUp(KeyCode.S))
			{
				print ("test");
				if (chargeTime <= 0)
				{
					//bicycle kick
				}
				else
				{
					levelPants[level].GetComponent<Animator>().SetTrigger("Kick");
				}
				chargeTime = chargeTotal;
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.S))
			{
				levelPants[level].GetComponent<Animator>().SetTrigger("Kick");
			}
		}
	
	}

	public void addPerson ()
	{
		peoplePantsed++;	
	}

	public void LevelUp()
	{
		levelPants [level].SetActive (false);
		level++;
		gameObject.GetComponent<Character_movement> ().level ++;
		levelPants [level].SetActive (true);
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
