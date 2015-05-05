using UnityEngine;
using System.Collections;

public class World3SoundControllerScript : MonoBehaviour {

	public AudioClip newClip;
	public Transform RobotPosition;
	private bool toplay = true;

	void Update () 
	{
		if (toplay && RobotPosition.position.x > 2450) 
		{
			toplay = false;
			audio.clip = newClip;
			audio.Play ();
		}
	}
}
