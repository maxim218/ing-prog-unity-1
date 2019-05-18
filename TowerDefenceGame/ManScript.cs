using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManScript : MonoBehaviour
{
    public GameObject e1, e2, e3;
    public GameObject Bullet;

    void Start()
    {
        
    }

    void fire(GameObject eee)
    {
        // turell
        Vector3 ppp = eee.transform.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(ppp);
        transform.rotation = rot;
        // fire bullet    
        GameObject s = Instantiate(Bullet) as GameObject;
        s.transform.position = transform.TransformPoint(Vector3.forward * 3.0f);
        Vector3 pos = transform.position - s.transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        s.transform.rotation = rotation;
        s.AddComponent<Rigidbody>();
        Rigidbody r = s.GetComponent<Rigidbody>();
        r.AddForce(transform.forward * 800);
    }

    private float maxTime = 2.0f;
    private float nowTime = 0.0f;

    void Update()
    {
        nowTime += Time.deltaTime;

        if (nowTime > maxTime)
        {
            nowTime = 0.0f;
            float d1 = (-1) * Vector3.Distance(gameObject.transform.position, e1.transform.position);
            float d2 = (-1) * Vector3.Distance(gameObject.transform.position, e2.transform.position);
            float d3 = (-1) * Vector3.Distance(gameObject.transform.position, e3.transform.position);
            Debug.Log(d1 + "  " + d2 + "  " + d3);
            if (d1 >= d2 && d1 >= d3) fire(e1);
            if (d2 >= d1 && d2 >= d3) fire(e2);
            if (d3 >= d1 && d3 >= d2) fire(e3);
        }
    }
}
