using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float rocketThrust = 750f;
    [SerializeField] float rotationSpeed = 200f;
    [SerializeField] AudioClip engineSound;

    [SerializeField] ParticleSystem lEngineParticles;
    [SerializeField] ParticleSystem rEngineParticles;
    

    Rigidbody rocketRigidBody;
    AudioSource rocketAudio;
   
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
            StartThrust();
        }
        else
        {
            StopThrust();
        }
        if (Input.GetKeyDown(KeyCode.Escape))//end the game
        {
            Application.Quit();
        }
    } 

    //start the thrusting sequence
    void StartThrust()
    {
        rocketRigidBody.AddRelativeForce(Vector3.up * rocketThrust * Time.deltaTime);//move the rocket in the way it is pointing
        if (!rocketAudio.isPlaying)//Check if audio is already playing so it does not loop on top of one another
        {
            rocketAudio.PlayOneShot(engineSound);
        }
        //play engine particles effect
        if (!rEngineParticles.isPlaying)
        {
            rEngineParticles.Play();
        }
        if (!lEngineParticles.isPlaying)
        {
            lEngineParticles.Play();
        }
    }
    
    //Stop the thrusting sequence
    void StopThrust()
    {
        lEngineParticles.Stop();
        rEngineParticles.Stop();
        rocketAudio.Stop();
    }

    //Processes input to rotate the rocket
    void ProcessRotation()
    { 
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            ApplyRotation(rotationSpeed);
        }

        else if (Input.GetKey(KeyCode.RightArrow))//dont rotate both ways at the same time
        {
            ApplyRotation(-rotationSpeed);
        }
    }
    
    //applies rotation to the rocket
    void ApplyRotation(float rotationThisFrame)
    {
        rocketRigidBody.freezeRotation = true; //Freeze rigidbody rotation so we can manually rotate while colliding with other objects
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rocketRigidBody.freezeRotation = false; //Unfreeze rigidbody rotation
    }
}
