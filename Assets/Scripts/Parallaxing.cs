﻿using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

	public Transform[] backgrounds;
	private float[] parralaxScales;
	public float smoothing = 1f;

	private Transform camera;
	private Vector3 previousCamPos;

	void Awake () {
		camera = Camera.main.transform;
	}

	// Use this for initialization
	void Start () {
		previousCamPos = camera.position;

		parralaxScales = new float[backgrounds.Length];

		for (int i = 0; i < backgrounds.Length; i++) {
			parralaxScales[i] = backgrounds[i].position.z*-1;
		}

	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < backgrounds.Length; i++) {

			float parallax = (previousCamPos.x - camera.position.x) * parralaxScales[i];

			float backgroundTargetPosX = backgrounds[i].position.x + parallax;

			Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

			backgrounds[i].position = Vector3.Lerp (backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
		}
		previousCamPos = camera.position;
	}
}
