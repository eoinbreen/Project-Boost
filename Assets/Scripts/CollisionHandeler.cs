using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                print("You Blew Up!!");
                break;
        }
    }
}
