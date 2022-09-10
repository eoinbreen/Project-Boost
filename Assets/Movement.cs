using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            print("Up Key is being Held Down");
        }

        if (Input.GetKey("down"))
        {
            print("Down Key is being Held Down");
        }
    }
}
