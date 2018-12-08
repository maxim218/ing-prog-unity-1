using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterTimeScript : MonoBehaviour {
	public int timeSeconds = 0;

	private IEnumerator deleteObject() {
		yield return new WaitForSeconds(timeSeconds);
		Destroy(gameObject);
	}

	void Start () {
		StartCoroutine(deleteObject());
	}
}
