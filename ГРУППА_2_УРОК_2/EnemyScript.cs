using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameObject hero = null;

    void Start()
    {
        hero = GameObject.Find("Hero");
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObj = collision.gameObject;
        Bullet script = hitObj.GetComponent<Bullet>();
        if(script)
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        Vector3 pos = hero.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = rotation;
        float speed = 2.5f;
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
