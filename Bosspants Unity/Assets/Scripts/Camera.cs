using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public GameObject player;
	public int LerpDistance;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x, player.transform.position.y +LerpDistance, -10), 0.5f);
		//transform.position= new Vector3(transform.position.x, player.transform.position.y-LerpDistance,transform.position.z);
//		transform.position.y= player.transform.position.y;
	}
}
