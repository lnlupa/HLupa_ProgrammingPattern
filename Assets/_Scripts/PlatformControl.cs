using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    //private Rigidbody platformRB;
    public float speed = 0.05f;
    public Vector3 inputForce = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        //platformRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlatform();
    }

    private void MovePlatform() 
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > -7.5f)
        {
            transform.Translate(new Vector3(-0.05f, 0, 0) * speed);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < 7.5f)
        {
            transform.Translate(new Vector3(0.05f, 0, 0) * speed);
        }
    }
}
