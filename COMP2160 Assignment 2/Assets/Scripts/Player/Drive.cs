using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Drive : MonoBehaviour
{
    public float speed = 10f;
    public float rotation = 90f; // amount of torque applied when turning
	public float hillSlideSpeed = 300f; // how quickly the car will slide downhill
	
	private Vector3 slope = new Vector3();
	
	private Rigidbody rb;
	
	private float slideScale; // A scale value for how much the car slides downhill based on its rotation.
	
	private bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }
	
	void FixedUpdate()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, -transform.up, out hit, 0.35f))
		{
			onGround = true;
		}
		else
		{
			onGround = false;
		}
		
		if(onGround)
		{
			if(Input.GetButton("Forward"))
			{
				rb.AddRelativeForce(Vector3.forward * speed * Time.deltaTime);
				
				if(Input.GetButton("Left"))
				{
					rb.AddRelativeTorque(Vector3.up * -rotation * Mathf.Max(0.6f, Input.GetAxis("Forward")) * Time.deltaTime, ForceMode.Acceleration);
				}
				else if(Input.GetButton("Right"))
				{
					rb.AddRelativeTorque(Vector3.up * rotation * Mathf.Max(0.6f, Input.GetAxis("Forward")) * Time.deltaTime, ForceMode.Acceleration);
				}
			}
			else if(Input.GetButton("Backward"))
			{
				rb.AddRelativeForce(Vector3.back * speed * Time.deltaTime);
				
				if(Input.GetButton("Left"))
				{
					rb.AddRelativeTorque(Vector3.up * rotation * Mathf.Max(0.6f, Input.GetAxis("Backward")) * Time.deltaTime, ForceMode.Acceleration);
				}
				else if(Input.GetButton("Right"))
				{
					rb.AddRelativeTorque(Vector3.up * -rotation * Mathf.Max(0.6f, Input.GetAxis("Backward")) * Time.deltaTime, ForceMode.Acceleration);
				}
			}
			else //when not moving in a direction, take the rotation vector of the object, invert it and move it back over time. Take this vector, flatten the y value, figure out which direction it is pointing and scale it accordingly.
			{
				// Cross product ideas from http://thehiddensignal.com/unity-angle-of-sloped-ground-under-player/
				
				// So the whole idea here is that the cross product results in a vector that is directly perpendicular to vectors crossed.
				
				// This first finds a vector that is directly perpendicular to both the down vector and the surface normal. However, this point is perpendicular to the direction we want.
				Vector3 perpendicular1 = Vector3.Cross(hit.normal, Vector3.down);
				
				// Using the normal and this new perpendicular vector, we can find the perpendicular vector to those, which points directly down the slope.
				slope = Vector3.Cross(perpendicular1, hit.normal);
				
				// We are applying a scaling value to the car's hill sliding based on the direction the car is facing relative to the slope angle, so 0 and 180 would let the car slide at full speed and 90 would cancel out the sliding entirely.
				float slideAngle = Vector3.Angle(slope,transform.forward);
				if(slideAngle <= 90)
				{
					slideScale = (90 - slideAngle)/90;
				}
				else if(slideAngle > 90 && slideAngle <= 180)
				{
					slideScale = -((90-slideAngle)/90);
					
				}
				
				// slide downhill
				rb.AddForce(slope.normalized * Time.deltaTime * hillSlideSpeed * slideScale);
			}
		}
	}
}
