using UnityEngine;
using System.Collections;

public class World3SoundControllerScript : MonoBehaviour {

	public AudioClip newClip;
	public Transform RobotPosition;
	private bool toplay = true;

	void Awake()
	{
		if (UIManagerScript.volumeValue == 0f)
			audio.volume = UIManagerScript.defaultValue;
		else
			audio.volume = UIManagerScript.volumeValue;
	}
	void Update () 
	{
		if (InGameCommandController.isAvailable)
			audio.volume = InGameCommandController.volumeValue;

		if (toplay && RobotPosition.position.x > 2450) 
		{
			toplay = false;
			audio.clip = newClip;
			audio.Play ();
		}
	}
}
