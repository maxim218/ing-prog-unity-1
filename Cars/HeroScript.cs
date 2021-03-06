﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour {
	private bool w, a, s, d;
	private GameObject car;
	public Camera heroCamera;
	public Camera carCamera;

	void Start () {
		Debug.Log ("Hero Start");
		initKeys ();
		car = GameObject.Find ("car");
		carCamera.enabled = false;
	}

	public void initKeys() {
		w = false;
		a = false;
		s = false;
		d = false;
	}

	void useCar() {
		float d = Vector3.Distance (transform.position, car.transform.position);
		if (d < 4.0f) {
			Debug.Log ("Sit to car");
			gameObject.SetActive(false);
			carCamera.enabled = true;
			heroCamera.enabled = false;
			car.GetComponent<CarScript> ().setCanMove (true);
		}
	}

	void move() {
		float speed = 4.0f;
		float speedRotate = 150.0f;
		float t = Time.deltaTime;

		if (Input.GetKeyDown(KeyCode.W)) w = true;
		if (Input.GetKeyDown(KeyCode.A)) a = true;
		if (Input.GetKeyDown(KeyCode.S)) s = true;
		if (Input.GetKeyDown(KeyCode.D)) d = true;

		if (Input.GetKeyUp(KeyCode.W)) w = false;
		if (Input.GetKeyUp(KeyCode.A)) a = false;
		if (Input.GetKeyUp(KeyCode.S)) s = false;
		if (Input.GetKeyUp(KeyCode.D)) d = false;

		if (w) transform.Translate (0, 0, t * speed);
		if (s) transform.Translate (0, 0, -1 * t * speed);
		if (a) transform.Rotate (0, -1 * t * speedRotate, 0);
		if (d) transform.Rotate (0, t * speedRotate, 0);
	}

	void Update () {
		move ();
		useCar ();
	}
}
