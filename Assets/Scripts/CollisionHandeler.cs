using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandeler : MonoBehaviour
{
    [SerializeField] AudioClip explosionSound;
    [SerializeField] AudioClip successSound;

    AudioSource rocketAudio;
    int currentLevel;
    bool isTransitioning = false; //Check if player is transitioning between levels
    void Start()
    {
        rocketAudio = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if(isTransitioning == false)
        {
            switch (collision.gameObject.tag)
            {
                case "Start":
                    print("On Starting Position");
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

    
    //Rocket Crashes
    void Crash()
    {
        /*
         
         To Do: Add effect on Crash
         */
        rocketAudio.Stop();
        rocketAudio.PlayOneShot(explosionSound);
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", 1f);//1 second delay to reloading Level
    }
    //reloads current Level
    void ReloadLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }

    void LevelComplete()
    {
        /*
         
         To Do: Add effect on Completing Level
         */
        rocketAudio.Stop();
        rocketAudio.PlayOneShot(successSound);
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", 1f);//1 second delay to loading next Level
    }


    void LoadNextLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = currentLevel + 1;
        if (currentLevel != SceneManager.sceneCount)//Check if current level is the final level
        {
            SceneManager.LoadScene(nextLevel);//Load next level
        }   
        else
        {
            print("You Won!! Restarting Game");
            SceneManager.LoadScene(0);//Load First Level
        }
    }
}
