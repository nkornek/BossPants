using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour
{

    public GameObject player;
    public int speed;
	public bool triggered;

    // Use this for initialization
    void Start()
    {
  
    }
    
    // Update is called once per frame
    void Update()
    {
            
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
            transform.Translate ((player.transform.position - transform.position)/speed, Space.Self);
        }
    }

    void OnCollisionEnter2D (Collision2D col)
    {
		if (col.transform.tag == "Player")
		{
			print ("collided");
			player.GetComponent <Player>() .addPerson();
			Destroy (gameObject);
		}
    }
}
