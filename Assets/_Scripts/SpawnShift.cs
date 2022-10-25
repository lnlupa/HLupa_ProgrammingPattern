using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShift : MonoBehaviour
{
    private float outerLimit = 7.5f;
    private float spawnSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (transform.position.x < outerLimit) 
        {
            transform.Translate(new Vector3(-0.05f, 0, 0) * spawnSpeed);
            Debug.Log("this happened");
        }
        if (transform.position.x > -outerLimit)
        {
            transform.Translate(new Vector3(0.05f, 0, 0) * spawnSpeed);
            Debug.Log("this happened");
        }*/
    }
}
