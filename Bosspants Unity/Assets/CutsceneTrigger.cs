using UnityEngine;
using System.Collections;

public class CutsceneTrigger : MonoBehaviour {
	public ParticleSystem part1, part2;

	void NextLevel()
	{
		Application.LoadLevel (1);
	}

	public void ShootParticles()
	{
		part1.Emit (50);
		part2.Emit (50);
	}
}
