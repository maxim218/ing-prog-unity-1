using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public Camera camera;
    private float waitTime;
    private float maxTime;

    float [] xArr = new float[100];
    float [] zArr = new float[100];

    int count = 0;

    bool canCreateCube(float xx, float zz)
    {
        for(int i = 0; i < count; i++)
        {
            float xxx = xArr[i];
            float zzz = zArr[i];
            float d = Mathf.Sqrt((xxx - xx) * (xxx - xx) + (zzz - zz) * (zzz - zz));
            if(d < 3.0f)
            {
                Debug.Log("Cube can NOT be created");
                return false;
            }
        }
        Debug.Log("Cube create OK");
        return true;
    }

    void pushCube(float xx, float zz)
    {
        xArr[count] = xx;
        zArr[count] = zz;
        count++;
    }

    void initArrays()
    {
        for(int i = 0; i < 100; i++)
        {
            xArr[i] = -9999.0f;
            zArr[i] = -9999.0f;
        }
    }

    void Start()
    {
        initArrays();
        waitTime = 3.1f;
        maxTime = 3.0f;
    }

    void incWaitTime()
    {
        if (waitTime <= 3.1f)
        {
            waitTime += Time.deltaTime;
        }
    }

    void clickMethod()
    {
        if(Input.GetMouseButton(0))
        {
            if (waitTime > maxTime)
            {
                waitTime = 0.0f;
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 pos = hit.point;
                    if (canCreateCube(hit.point.x, hit.point.z) == true)
                    {
                        GameObject myCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        myCube.transform.localScale = new Vector3(2, 2, 2);
                        myCube.transform.position = new Vector3(hit.point.x, 2, hit.point.z);
                        pushCube(hit.point.x, hit.point.z);             
                    }
                }
            }
        }
    }

    void Update()
    {
        clickMethod();
        incWaitTime();
    }
}
