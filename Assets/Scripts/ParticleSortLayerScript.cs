﻿using UnityEngine;
using System.Collections;

public class ParticleSortLayerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = "Ground";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
