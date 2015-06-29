using UnityEngine;
using System.Collections;

public class World4SoundController : MonoBehaviour {

	public AudioClip newClip;
	public AudioClip OldClip;
	public Transform RobotPosition;
	private bool toplay = true;
	private bool toplayagain = true;
	
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
		
		if (toplay && RobotPosition.position.x > 1800) 
		{
			toplay = false;
			audio.clip = newClip;
			audio.Play ();
		}
		if (toplayagain && UIManagerScript.isWorld4finished) 
		{
			toplayagain = false;
			audio.clip = OldClip;
			audio.Play();
		}
	}
}
