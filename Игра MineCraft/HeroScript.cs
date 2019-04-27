using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    private bool a, w, d;

    void Start()
    {
        a = false;
        w = false;
        d = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) a = true;
        if (Input.GetKeyDown(KeyCode.W)) w = true;
        if (Input.GetKeyDown(KeyCode.D)) d = true;

        if (Input.GetKeyUp(KeyCode.A)) a = false;
        if (Input.GetKeyUp(KeyCode.W)) w = false;
        if (Input.GetKeyUp(KeyCode.D)) d = false;

        float t = Time.deltaTime;
        float speed = 5.0f;
        float rotationSpeed = 120.0f;

        if (w == true) transform.Translate(0, 0, speed * t);
        if (a == true) transform.Rotate(0, (-1) * rotationSpeed * t, 0);
        if (d == true) transform.Rotate(0, rotationSpeed * t, 0);
    }
}
