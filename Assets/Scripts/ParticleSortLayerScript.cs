using UnityEngine;
using System.Collections;

public class ParticleSortLayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = "Ground";
		particleSystem.renderer.sortingOrder = 1000;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
