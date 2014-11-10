using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float triggerDistance;
	public int peoplePantsed, peopleToPants;
	public GameObject[] levelPants;
	public int level;

	public float kickTime, maxKickTime, kickForce;
	public bool kicking;

	public int damageTaken;
	public float ejectForce;

	public Audiosource audioguy;

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
			rigidbody2D.AddForce( Vector2.right * levelPants[level].transform.localScale.x * kickForce);
			if (kickTime <= 0)
			{
				kicking = false;
				levelPants[level].GetComponent<Animator>().SetBool("Kicking", false);
			}
		}
		if (level == 0 & peoplePantsed == 5)
		{
			levelPants[level].GetComponent<Animator>().SetTrigger ("SPINKIKKU");
			//LevelUp();
		}
		if (level == 1 & peoplePantsed == 10)
		{
			levelPants[level].GetComponent<Animator>().SetTrigger ("SPINKIKKU");
			//LevelUp();
		}
	
	}

	public void addPerson ()
	{
		peoplePantsed++;	
	}

	public void LevelUp()
	{
		//audioguy.GetInsideThePants ();
		levelPants [level].SetActive (false);
		level++;
		gameObject.GetComponent<Character_movement> ().level ++;
		levelPants [level].SetActive (true);
		Invoke ("LoadNextLevel", 1);
	}

	public void CallPeople() 
	{
		foreach (GameObject person in GameObject.FindGameObjectsWithTag("person"))
		{
			if (Mathf.Abs (Vector2.Distance(person.transform.position, transform.position)) < triggerDistance * (level + 1) && person.GetComponent <Person>().triggered == false)
			{
				//trigger some speech bubblin
				person.GetComponent <Person>().triggered = true;
			}
		}
	}

	public void TakeDamage()
	{
		int loss = 0;
		while (loss < peoplePantsed)
		{
			GameObject person = Instantiate(Resources.Load("person"), new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity) as GameObject;
			float randomX = Random.Range(-1, 1);
			float randomY = Random.Range(0, 1);
			person.GetComponent<Rigidbody2D>().AddForce(new Vector2(randomX, randomY) * ejectForce);
			loss ++;
		}
		peoplePantsed = 0;
	}

	
	void LoadNextLevel()
	{
		CancelInvoke("LoadNextLevel");
		Application.LoadLevel (Application.loadedLevel + 1);

	}

}
