using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    float myTime = 0.0f;

    bool a, d;
    
    void Start()
    {
        myTime = 0.0f;
        a = false;
        d = false;
    }

    
    void Update()
    {
        if (myTime < 1.5f)
        {
            myTime += Time.deltaTime;
        }

        if(Input.GetMouseButtonDown(0))
        {
            if(myTime > 1.0f)
            {
                myTime = 0.0f;
                GameObject b = Instantiate(bulletPrefab) as GameObject;
                b.transform.position = transform.TransformPoint(Vector3.forward * 1.0f);
                Vector3 pos = transform.position - b.transform.position;
                Quaternion rotation = Quaternion.LookRotation(pos);
                b.transform.rotation = rotation;
                Rigidbody script = b.GetComponent<Rigidbody>();
                script.AddForce(transform.forward * 2500);
                script.AddForce(transform.up * 100);
            }
        }

        Debug.Log("MyTime: " + myTime);

        float rotateSpeed = 150.0f;

        if (Input.GetKeyDown(KeyCode.A)) a = true;
        if (Input.GetKeyDown(KeyCode.D)) d = true;

        if (Input.GetKeyUp(KeyCode.A)) a = false;
        if (Input.GetKeyUp(KeyCode.D)) d = false;

        if(a == true) transform.Rotate(0, -1 * rotateSpeed * Time.deltaTime, 0); 
        if(d == true) transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
