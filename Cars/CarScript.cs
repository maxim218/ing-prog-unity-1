using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour {
	private bool w, a, s, d;
	private bool canMove;
	private GameObject hero;
	public Camera heroCamera;
	public Camera carCamera;

	void Start () {
		Debug.Log ("Car Start");
		initKeys ();
		hero = GameObject.Find ("hero");
		canMove = false;
	}

	public void initKeys() {
		w = false;
		a = false;
		s = false;
		d = false;
	}

	public void setCanMove(bool value) {
		canMove = value;
	}

	void outFromCar() {
		canMove = false;
		hero.SetActive(true);
		carCamera.enabled = false;
		heroCamera.enabled = true;
		hero.GetComponent<HeroScript> ().initKeys ();
		hero.transform.position = transform.position;
		hero.transform.Translate (4.5f, 0, 0);
		Debug.Log ("Out from car");
	}

	void OnGUI() {
		if (canMove == true) {
			if (GUI.Button (new Rect (40, 40, 200, 50), "Выйти из машины")) {
				canMove = false;
				outFromCar ();
			}
		}
	}
	
	void move() {
		float speed = 20.0f;
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
		if (canMove == true) {
			move ();
		}
	}
}
