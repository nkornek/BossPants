using UnityEngine;
using System.Collections;

public class CutsceneTrigger : MonoBehaviour {

	void NextLevel()
	{
		Application.LoadLevel (1);
	}
}
