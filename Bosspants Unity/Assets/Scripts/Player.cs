using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float triggerDistance;
	public int peoplePantsed, peopleToPants;
	public GameObject[] levelPants;
	public int level;

	public float kickTime, maxKickTime, kickForce;
	public bool kicking;

	// Use this for initialization
	void Start () {
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
			if (Input.GetKey(KeyCode.S) & !kicking & kickTime < maxKickTime)
			{
				kickTime += Time.deltaTime;
			}
			if (Input.GetKeyUp(KeyCode.S) & !kicking)
			{
				kicking = true;
				levelPants[level].GetComponent<Animator>().SetBool("Kicking", true);
			}
		}
		else
		{
			if (Input.GetKeyDown(KeyCode.S))
			{
				levelPants[level].GetComponent<Animator>().SetTrigger("Kick");
			}
		}

		//launch bicycle kick
		if (kicking)
		{
			kickTime -= Time.deltaTime;
			rigidbody2D.AddForce( Vector2.right * transform.localScale.x * kickForce);
			if (kickTime <= 0)
			{
				kicking = false;
				levelPants[level].GetComponent<Animator>().SetBool("Kicking", false);
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
