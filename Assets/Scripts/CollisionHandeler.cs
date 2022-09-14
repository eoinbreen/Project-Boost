using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandeler : MonoBehaviour
{
    int currentLevel; 
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Start":
                print("On Starting Position");
                break;
            case "Finish":
                LevelComplete();
                LoadNextLevel();
                break;
            default:
                Crash();
                break;
        }
    }

    
    //Rocket Crashes
    void Crash()
    {
        /*
         To Do: Add Sound Upon Crash
         To Do: Add effect on Crash
         */
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
         To Do: Add Sound Upon Completing Level
         To Do: Add effect on Completing Level
         */
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", 1f);//1 second delay to loading next Level
    }


    void LoadNextLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel != SceneManager.sceneCount)//Check if current level is the final level
        {
            print("Loading Next Level");
            SceneManager.LoadScene(currentLevel ++);//Load next level
        }   
        else
        {
            print("You Won!! Restarting Game");
            SceneManager.LoadScene(0);//Load First Level
        }
    }
}
