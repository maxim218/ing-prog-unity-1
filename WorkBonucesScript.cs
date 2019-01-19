using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkBonucesScript : MonoBehaviour
{
    bool hat = false;
    GameObject hatObject = null;

    bool e, r;

    void Start()
    {
        hat = false;
        hatObject = null;
        e = false;
        r = false;
    }

    void dropHat()
    {
        if (Input.GetKeyDown(KeyCode.R)) r = true;
        if (Input.GetKeyUp(KeyCode.R)) r = false;

        if(r == true && hat == true)
        {
            if(hatObject != null)
            {
                hat = false;
                hatObject.AddComponent<Rigidbody>();
                Rigidbody rigigbodyScript = hatObject.GetComponent<Rigidbody>();
                rigigbodyScript.mass = 15.0f;
                rigigbodyScript.AddForce(transform.forward * 4000);
                hatObject = null;
            }
        }
    }

    void moveHat()
    {
        if (hat == true)
        {
            if (hatObject != null)
            {
                hatObject.transform.position = transform.position;
                hatObject.transform.Translate(0, 2.5f, 0, Space.World);
                hatObject.transform.rotation = transform.rotation;
            }
        }
    }

    void catchCube()
    {
        if (Input.GetKeyDown(KeyCode.E)) e = true;
        if (Input.GetKeyUp(KeyCode.E)) e = false;

        if (hat == false && e == true)
        {
            Bonus[] arr = FindObjectsOfType(typeof(Bonus)) as Bonus[];
            for (int i = 0; i < arr.Length; i++)
            {
                float d = Vector3.Distance(arr[i].gameObject.transform.position, transform.position);
                if (d < 2.8f)
                {
                    hat = true;
                    hatObject = arr[i].gameObject;
                    hatObject.transform.position = transform.position;
                    hatObject.transform.Translate(0, 2.5f, 0, Space.World);
                    Rigidbody r = hatObject.GetComponent<Rigidbody>();
                    Destroy(r);
                    break;
                }
            }
        }
    }


    void Update()
    {
        moveHat();
        catchCube();
        dropHat();
    }
}
