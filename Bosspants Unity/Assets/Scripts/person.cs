using UnityEngine;
using System.Collections;

public class person : MonoBehaviour
{

    public GameObject player;
    public float triggerDistance;
    public int speed;
    // Use this for initialization
    void Start()
    {
    
    }
    
    // Update is called once per frame
    void Update()
    {
            
        if (Vector2.Distance(transform.position, player.transform.position) < triggerDistance)
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

    void OnCollisionEnter (Collision collisionInfo)
    {

    }
}
