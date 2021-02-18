using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float velocity1;

    float acceleration;

    float maxvelocity;

    bool movement = true;

    // Start is called before the first frame update
    void Start()
    {
        velocity1 = 0.5f;
        acceleration = 0.05f;
        maxvelocity = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (movement)
        {
            MoveTheCamera();
        }        
    }

    void MoveTheCamera()
    {
        transform.position += transform.up * velocity1 * Time.deltaTime;
        velocity1 += acceleration * Time.deltaTime;
        if (velocity1 > maxvelocity)
        {
            velocity1 = maxvelocity;
        }
    }

}
