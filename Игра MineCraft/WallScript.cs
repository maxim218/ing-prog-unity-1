using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    GameObject hero = null;
    bool e = false;
    bool canAdd = true;

    void Start()
    {
        hero = GameObject.Find("Hero");
        e = false;
        canAdd = true;
    }

  
    void Update()
    {
        if (canAdd == true)
        {
            if (Input.GetKeyDown(KeyCode.E)) e = true;
            if (Input.GetKeyUp(KeyCode.E)) e = false;

            if (e == true)
            {
                float d = Vector3.Distance(hero.transform.position, transform.position);
                if (d < 4.1f)
                {
                    gameObject.AddComponent<Rigidbody>();
                    canAdd = false;
                }
            }
        }
    }
}
