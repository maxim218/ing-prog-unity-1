using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
	public int live = 0;
	public GameObject DeadEnemy;
	private GameObject hero;

	void Start() {
		hero = GameObject.Find ("Hero");
	}

	private void OnCollisionEnter(Collision collision) {
		BulletScript script = collision.gameObject.GetComponent<BulletScript>();
		if (script) {
			live -= 1;
			Destroy(collision.gameObject);
		}
	}

	void move() {
		float speed = 7.0f;
		float t = Time.deltaTime;
		transform.Translate (0, 0, speed * t);

		Ray ray = new Ray(transform.position, transform.forward);
		RaycastHit hit;
		if (Physics.SphereCast (ray, 0.5f, out hit)) {
			if ((hit.distance < 2.5f)) {
				transform.Rotate(0, 180, 0);
			}
		}
	}

	void hitWithHero() {
		if (hero) {
			float d = Vector3.Distance (transform.position, hero.transform.position);
			if (d < 6.5f) {
				Debug.Log ("Hit with hero");
				hero.GetComponent<HeroScript>().showDeadCamera();
				Destroy (hero);
			}
		}
	}

	void Update () {
		move ();
		hitWithHero ();

		if (live <= 0) {
			GameObject deadEnemy = Instantiate (DeadEnemy) as GameObject;
			deadEnemy.transform.position = transform.position;
			Destroy(gameObject);
			return;
		}
	}
}
