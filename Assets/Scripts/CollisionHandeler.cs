using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandeler : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Start":
                print("On Starting Position");
                break;
            case "Finish":
                print("Level Complete");
                break;
            case "Fuel":
                print("You Picked Up Fuel");
                break;
            default:
                ReloadLevel();
                break;
        }
    }
    //reloads current Level
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
