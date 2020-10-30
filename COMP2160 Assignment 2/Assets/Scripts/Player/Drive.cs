using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Drive : MonoBehaviour
{
    public float speed = 10f;
    public float rotation = 90f; //in degrees
	
	private float angle = 0f;
	
	private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log(Input.GetAxis("Forward"));
    }
	
	void FixedUpdate()
	{	
		if(Input.GetButton("Forward"))
		{
			rigidbody.AddRelativeForce(Vector3.forward * speed * Time.deltaTime);
			
			if(Input.GetButton("Left"))
			{
				rigidbody.AddRelativeTorque(Vector3.up * -rotation * Mathf.Max(0.6f, Input.GetAxis("Forward")) * Time.deltaTime, ForceMode.Acceleration);
			}
			else if(Input.GetButton("Right"))
			{
				rigidbody.AddRelativeTorque(Vector3.up * rotation * Mathf.Max(0.6f, Input.GetAxis("Forward")) * Time.deltaTime, ForceMode.Acceleration);
			}
		}
		else if(Input.GetButton("Backward"))
		{
			rigidbody.AddRelativeForce(Vector3.back * speed * Time.deltaTime);
			
			if(Input.GetButton("Left"))
			{
				rigidbody.AddRelativeTorque(Vector3.up * -rotation * Mathf.Max(0.6f, Input.GetAxis("Backward")) * Time.deltaTime, ForceMode.Acceleration);
			}
			else if(Input.GetButton("Right"))
			{
				rigidbody.AddRelativeTorque(Vector3.up * rotation * Mathf.Max(0.6f, Input.GetAxis("Backward")) * Time.deltaTime, ForceMode.Acceleration);
			}
		}
		else //when not moving in a direction, take the rotation vector of the object, invert it and move it back over time. Take this vector, flatten the y value, figure out which direction it is pointing and scale it accordingly.
		{
			
		}
	}
}
