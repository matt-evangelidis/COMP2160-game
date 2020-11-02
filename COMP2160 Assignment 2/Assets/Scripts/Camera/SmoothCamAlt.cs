﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamAlt : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 1f; //time it takes the camera to reach the target
    public Vector3 defaultDistance = new Vector3(0f, 0f, -2f); //the point the camera follows
    private Vector3 velocity = Vector3.zero; //velocity for SmoothDamp

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        SmoothFollow();
    }

    void SmoothFollow()
    {
        //adapted from BergZerg's video: https://www.youtube.com/watch?v=3vYaDZgJj5Y&ab_channel=BurgZergArcade

        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 curPos = Vector3.SmoothDamp(transform.position, toPos, ref velocity, smoothTime);

        transform.position = curPos;
        transform.LookAt(target, target.up);
    }
}