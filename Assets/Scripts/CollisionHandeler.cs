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
                LoadNextLevel();
                break;
            default:
                ReloadLevel();
                break;
        }
    }
    //reloads current Level
    void ReloadLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentLevel);
    }

    void LoadNextLevel()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel != SceneManager.sceneCount)//Check if current level is the final level
        {
            print("Loading Next Level");
            SceneManager.LoadScene(currentLevel + 1);//Load next level
        }   
        else
        {
            print("You Won!! Restarting Game");
            SceneManager.LoadScene(0);//Load First Level
        }
    }
}
