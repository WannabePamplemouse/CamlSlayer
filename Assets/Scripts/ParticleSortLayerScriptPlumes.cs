using UnityEngine;
using System.Collections;

public class ParticleSortLayerScriptPlumes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = "Background";
		particleSystem.renderer.sortingOrder = 1000;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
