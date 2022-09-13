using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rocketRigidBody;
    AudioSource rocketAudio;
    [SerializeField] float rocketThrust = 750f;
    [SerializeField] float rotationSpeed = 200f;
    // Start is called before the first frame update
    void Start()
    {
        rocketRigidBody = GetComponent<Rigidbody>();
        rocketAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    //processes input to add thrust to the Rocket
    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rocketRigidBody.AddRelativeForce(Vector3.up * rocketThrust * Time.deltaTime);
            if (!rocketAudio.isPlaying)//Check if audio is already playing so it does not loop on top of one another
            {
                rocketAudio.Play();
            }
        }
        else
        {
            rocketAudio.Pause();
        }
    }

    //Processes input to rotate the rocket
    void ProcessRotation()
    { 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotationSpeed);
        }

        else if (Input.GetKey(KeyCode.RightArrow))//dont rotate both ways at a time
        {
            ApplyRotation(-rotationSpeed);
        }
    }
    
    //applies rotation to the rocket
    void ApplyRotation(float rotationThisFrame)
    {
        rocketRigidBody.freezeRotation = true; //Freeze rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rocketRigidBody.freezeRotation = false; //Unfreeze rotation
    }
}
