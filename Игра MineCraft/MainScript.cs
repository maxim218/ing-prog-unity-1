using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public GameObject P1, P2, P3;

    void createCube(float xx, float yy, float zz, int cubeType)
    {
        GameObject cube = null;

        if (cubeType == 1) cube = Instantiate(P1) as GameObject;
        if (cubeType == 2) cube = Instantiate(P2) as GameObject;
        if (cubeType == 3) cube = Instantiate(P3) as GameObject;

        cube.transform.position = new Vector3(xx, yy, zz);
    }

    void buildFloor()
    {
        int n = 30;
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < n; j++)
            {
                createCube(i, 0.0f, j, 1);
            }
        }
    }

    void buildLabirint()
    {
        int n = 30;

        for(int i = 0; i < n; i++)
        {
            createCube(i, 1.0f, 0, 3);
            createCube(i, 2.0f, 0, 3);
        }
    }


    void Start()
    {
        buildFloor();
        buildLabirint();
    }

    void Update()
    {
        
    }
}
