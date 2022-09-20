using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandeler : MonoBehaviour
{
    [SerializeField] AudioClip explosionSound;
    [SerializeField] AudioClip successSound;

    [SerializeField] ParticleSystem explosionParticles;
    [SerializeField] ParticleSystem successParticles;

    AudioSource rocketAudio;
    int currentLevel;
    bool isTransitioning = false; //Check if player is transitioning between levels
    bool collisionsOn = true;
    void Start()
    {
        rocketAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        DebugInputs();
    }

    private void DebugInputs()
    {
        if (Input.GetKeyDown(KeyCode.C))// Toggle Collisions with C Key
        {
            collisionsOn = !collisionsOn;
        }
        if (Input.GetKeyDown(KeyCode.L))//Load Next Level with L Key
        {
            LoadNextLevel();
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if(isTransitioning == false && collisionsOn)
        {
            switch (collision.gameObject.tag)
            {
                case "Start":
                    break;
                case "Finish":
                    LevelComplete();
                    break;
                default:
                    Crash();
                    break;
            }
        }
        
        
    }

    
    //Start Crash Sequence
    void Crash()
    {
        explosionParticles.Play();
        rocketAudio.Stop();
        rocketAudio.PlayOneShot(explosionSound);
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", 1f);//1 second delay on reloading Level to play audio and particles
    }

    void LevelComplete()
    {
        successParticles.Play();
        rocketAudio.Stop();
        rocketAudio.PlayOneShot(successSound);
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", 1f);
    }
    
    void ReloadLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }

    void LoadNextLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentLevel + 1;
        if (nextLevel != SceneManager.sceneCountInBuildSettings)//Check if this is the final level
        {
            SceneManager.LoadScene(nextLevel);
        }   
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
