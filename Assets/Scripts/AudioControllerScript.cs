using UnityEngine;
using System.Collections;

public class AudioControllerScript : MonoBehaviour {
	
	public Transform RobotPosition;
	public AudioClip newClip;
	private bool toplay = true;

	void Awake()
	{
		if (UIManagerScript.volumeValue == 0f)
			audio.volume = UIManagerScript.defaultValue;
		else
			audio.volume = UIManagerScript.volumeValue;
	}
	void Update()
	{
		if(toplay && RobotPosition.position.x > 450)
		{
			toplay = false;
			audio.clip = newClip;
			audio.Play();
		}


	}
}
