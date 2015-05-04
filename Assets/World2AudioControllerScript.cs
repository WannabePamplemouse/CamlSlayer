using UnityEngine;
using System.Collections;

public class World2AudioControllerScript : MonoBehaviour {

	[SerializeField]
	private Transform RobotPosition;
	[SerializeField]
	private AudioClip newClip;

	void Update()
	{
		if (RobotPosition.position.x > 2200) 
		{
			audio.clip = newClip;
			audio.Play();
		}
	}
}
