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

            createCube(i, 1.0f, n - 1, 3);
            createCube(i, 2.0f, n - 1, 3);
        }

        for(int i = 1; i <= n - 2; i++)
        {
            createCube(0, 1.0f, i, 3);
            createCube(0, 2.0f, i, 3);

            createCube(n - 1, 1.0f, i, 3);
            createCube(n - 1, 2.0f, i, 3);
        }

        for(int i = 4; i < n - 6; i++)
        {
            createCube(5, 1.0f, i, 3);
            createCube(5, 2.0f, i, 3);

            createCube(12, 1.0f, i, 3);
            createCube(12, 2.0f, i, 3);

            createCube(18, 1.0f, i, 3);
            createCube(18, 2.0f, i, 3);

            createCube(25, 1.0f, i, 3);
            createCube(25, 2.0f, i, 3);
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
