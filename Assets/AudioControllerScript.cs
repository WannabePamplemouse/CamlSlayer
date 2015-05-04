using UnityEngine;
using System.Collections;

public class AudioControllerScript : MonoBehaviour {

	[SerializeField]
	private Transform RobotPosition;
	[SerializeField]
	private AudioClip newClip;

	void Update()
	{
		if(RobotPosition.position.x > 450)
		{
			audio.clip = newClip;
			audio.Play();
		}
	}
}
