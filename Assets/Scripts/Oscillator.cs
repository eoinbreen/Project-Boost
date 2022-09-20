using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 3f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        print(startingPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon){ return; }// dont run below code if period is below Mathf.Epsilon as you cannot divide by zero - better to use Mathf.Epsilon rather than 0

        float cycles = Time.time / period;//continually Growing over Time

        const float tau = Mathf.PI * 2; // constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles * tau); // going from -1 to 1 over time

        movementFactor = rawSinWave;

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset; //moving object form one position to another
    }
}
