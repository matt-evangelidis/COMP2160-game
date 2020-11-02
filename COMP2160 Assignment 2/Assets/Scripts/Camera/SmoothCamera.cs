using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public Rigidbody target;
    public float posSmoothing = 0.5f;
    public float rotSmoothing = 0.5f;
    public LayerMask groundLayer;

    private Vector3 oldPos;
    private Vector3 newPos;

    private Quaternion oldRot;
    private Quaternion newRot;

    // Start is called before the first frame update
    void Start()
    {
        oldPos = Vector3.zero;
        newPos = Vector3.zero;

        oldRot = Quaternion.identity;
        newRot = Quaternion.identity;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //set update position and rotation
        newPos = target.position - target.velocity;
        newRot = target.rotation * Quaternion.Euler(target.velocity);

        //linearly interpolate for position and rotation
        Vector3 posOffset = Vector3.LerpUnclamped(oldPos, newPos, posSmoothing * Time.deltaTime);
        Quaternion rotOffset = Quaternion.LerpUnclamped(oldRot, newRot, rotSmoothing * Time.deltaTime);

        //set
        transform.position = posOffset;//Vector3.ClampMagnitude(posOffset, 0.1f);
        transform.rotation = rotOffset;
/*
        Ray ray = new Ray(target.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            transform.position = new Vector3(posOffset.x, hit.point.y, posOffset.z);
        }*/

        oldPos = posOffset;
        oldRot = rotOffset;

    }

}
