using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private bool doneMoving;
    IEnumerator currentCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        doneMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (doneMoving)
        {
            if(currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
            }
            currentCoroutine = Move(Random.onUnitSphere * 6, 1f);
            StartCoroutine(currentCoroutine);
        }
    }

    IEnumerator Move(Vector3 destination, float speed)
    {
        doneMoving = false;
        var velocity = Vector3.zero;
        while(transform.position != destination){
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, .2f, 1);
            yield return null;
        }
        doneMoving = true;
    }
}
