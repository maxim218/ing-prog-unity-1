using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour {
	private float speedMoving;
	private float speedRotating;
	private bool w, a, s, d;

	public GameObject Bullet;
	public Camera deadCamera;

	void Start () {
		speedMoving = 15.0f;
		speedRotating = 120.0f;
		w = false;
		a = false;
		s = false;
		d = false;
		deadCamera.enabled = false;
	}

	public void showDeadCamera() {
		deadCamera.enabled = true;
	}

	void fire() {
		if (Input.GetMouseButtonDown (0)) {
			GameObject bullet = Instantiate (Bullet) as GameObject;
			bullet.transform.position = transform.TransformPoint (Vector3.forward * 4.0f);

			Vector3 pos = transform.position - bullet.transform.position;
			Quaternion rotation = Quaternion.LookRotation(pos);
			bullet.transform.rotation = rotation;

			Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
			rigidbody.AddForce(transform.forward * 5000.0f);
			rigidbody.AddForce(transform.up * 200.0f);
		}
	}

	void moveAndRotate() {
		if (Input.GetKeyDown (KeyCode.W)) w = true;
		if (Input.GetKeyDown (KeyCode.A)) a = true;
		if (Input.GetKeyDown (KeyCode.S)) s = true;
		if (Input.GetKeyDown (KeyCode.D)) d = true;

		if (Input.GetKeyUp (KeyCode.W)) w = false;
		if (Input.GetKeyUp (KeyCode.A)) a = false;
		if (Input.GetKeyUp (KeyCode.S)) s = false;
		if (Input.GetKeyUp (KeyCode.D)) d = false;

		float t = Time.deltaTime;

		if (w) transform.Translate (0, 0, speedMoving * t);
		if (s) transform.Translate (0, 0, speedMoving * t * (-1));
		if (a) transform.Rotate (0, speedRotating * t * (-1), 0);
		if (d) transform.Rotate (0, speedRotating * t, 0);
	}

	void Update () {
		moveAndRotate ();
		fire ();
	}
}
