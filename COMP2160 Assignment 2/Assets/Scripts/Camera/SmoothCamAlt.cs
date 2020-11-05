using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamAlt : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 1f; //time it takes the camera to reach the target
    public Vector3 defaultDistance = new Vector3(0f, 0f, -2f); //the point the camera follows
    public Vector3 velocity = Vector3.zero; //velocity for SmoothDamp
    public float minDistance = 0.15f;
    public float maxDistance = 1.5f;


    // Update is called once per frame
    void LateUpdate()
    {
        SmoothFollow();
    }

    void SmoothFollow()
    {
        //adapted from BergZerg's video: https://www.youtube.com/watch?v=3vYaDZgJj5Y&ab_channel=BurgZergArcade

        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        
        //smoothTime gets scaled by velocity.magnitude to increase the distance from the camera to the player as it accelerates
        //smoothTime is clamped between minDistance and maxDistance
        smoothTime = Mathf.Clamp(smoothTime * velocity.magnitude, minDistance, maxDistance);
        
        //As the player accelerates, smoothTime will reach maxDistance, and smoothTime will be halved 
        //to allow the camera to remain at a reasonable distance
        if (smoothTime == maxDistance)
        {
            smoothTime = maxDistance/2;
        }
        
        Vector3 curPos = Vector3.SmoothDamp(transform.position, toPos, ref velocity, smoothTime);

        transform.position = curPos;
        transform.LookAt(target, target.up);
    }
}
