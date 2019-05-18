using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteScript : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(killMe());
    }

    private IEnumerator killMe()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
