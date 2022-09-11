using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rocketRigidBody;
    [SerializeField] float mainThrust = 1f;
    [SerializeField] float rotationThrust = 1f;
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
            rocketRigidBody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.RightArrow))//dont rotate both ways at a time
        {
            transform.Rotate(Vector3.back * rotationThrust * Time.deltaTime);
        }
    }
}
