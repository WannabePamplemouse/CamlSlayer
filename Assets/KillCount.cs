using UnityEngine;
using System.Collections;

public class KillCount : MonoBehaviour {

	public int enemyKilled;

	void Awake()
	{
		enemyKilled = 0;
	}

}
