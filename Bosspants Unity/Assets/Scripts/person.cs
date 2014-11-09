using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour
{

    public GameObject player, chaseTarget;
    public int speed;
	public bool triggered;
	
	public Sprite[] personSprites;
	public Vector2 prevPos;


    // Use this for initialization
    void Start()
    {
		chaseTarget = GameObject.Find ("ChaseTarget");
		player = GameObject.FindGameObjectWithTag ("Player");
		int randomInt = Random.Range (0, personSprites.Length);
		gameObject.GetComponent<SpriteRenderer> ().sprite = personSprites [randomInt];
  
    }
    
    // Update is called once per frame
    void Update()
    {
		//set facing
		if (transform.position.x >= prevPos.x)
		{
			transform.localScale = new Vector2(1, 1);
		}
		else
		{
			transform.localScale = new Vector2(-1, 1);
		}
		prevPos = transform.position;
            
        if (triggered)
        {
           /* if (transform.position.x - player.transform.position.x < 0)
            {
                transform.Translate(Vector2.right * -speed * Time.deltaTime, Space.Self);
            }
            else 
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime, Space.Self);
            }*/
			print ("person triggered");
            transform.Translate ((chaseTarget.transform.position - transform.position)/speed, Space.Self);
        }
    }

    void OnCollisionEnter2D (Collision2D col)
    {
		if (col.transform.tag == "Player" & triggered)
		{
			print ("collided");
			player.GetComponent <Player>() .addPerson();
			Destroy (gameObject);
		}
    }
}
