using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{

    public float speed = 10f;
    public float rotation = 90f; //in degrees

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float inputVelocity = Input.GetAxis("Vertical") * speed;
        float inputRotation = Input.GetAxis("Horizontal") * rotation;

        inputVelocity *= Time.deltaTime;
        inputRotation *= Time.deltaTime;

        transform.Translate(0, 0, inputVelocity);

        if (inputVelocity != 0)//can only turn when the car is in motion
        {
            transform.Rotate(0, inputRotation, 0);
        }

    }
}
