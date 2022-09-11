using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rocketRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
        rocketRigidBody = GetComponent<Rigidbody>();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rocketRigidBody.AddRelativeForce(0, 1, 0);
            print("Spacebar is being Held Down");
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            print("Left Key is being Held Down");
        }

        else if (Input.GetKey(KeyCode.RightArrow))//dont rotate both ways at a time
        {
            print("Right Key is being Held Down");
        }
    }
}
