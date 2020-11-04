using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Rigidbody target;
    public float posSmoothing = 0.5f;
    public float rotSmoothing = 0.5f;
    public LayerMask groundLayer;
    public float maxDistance;

    private float posSmoothingStored;

    private Vector3 oldPos;
    private Vector3 newPos;

    private Quaternion oldRot;
    private Quaternion newRot;

    private Transform targetTransform;

    // Start is called before the first frame update
    void Start()
    {
        oldPos = transform.position;
        newPos = transform.position;

        oldRot = Quaternion.identity;
        newRot = Quaternion.identity;

        targetTransform = target.transform;
        posSmoothingStored = posSmoothing;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Debug.Log("Target Pos: " + target.position.ToString());

        //set update position and rotation
        newPos = target.position - target.velocity;
        newRot = target.rotation * Quaternion.Euler(target.velocity);

/*        if (Vector3.Distance(target.position, newPos) > maxDistance)
        {
            newPos = 
        }*/

        Debug.Log("Velocity: " + target.velocity.ToString());

        //linearly interpolate for position and rotation
        Vector3 posOffset = Vector3.LerpUnclamped(oldPos, newPos, posSmoothing * Time.deltaTime);
        Quaternion rotOffset = Quaternion.LerpUnclamped(oldRot, newRot, rotSmoothing * Time.deltaTime);

        //set
        transform.position = posOffset;
        transform.rotation = rotOffset;

        //Debug.Log("Distance, pivot to target:" + Vector3.Distance(transform.position, target.position));

        oldPos = posOffset;
        oldRot = rotOffset;

    }

}
