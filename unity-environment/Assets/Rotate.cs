using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class Rotate : MonoBehaviour {
    Rigidbody rb;
	public ForceMode mode = ForceMode.Acceleration;
	public float force = 50;
    public float maxZ = 0.16f;
    public float minZ = -0.16f;

	public bool playerControllable = false;
	Vector3 cPos;
	// Use this for initialization
	void Start () {
		cPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
		rb = GetComponent<Rigidbody> ();
		rb.maxAngularVelocity = 200f;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//rb.AddTorque(Vector3.forward*force,mode);
		if (!playerControllable)
			return;

        var inputDevice = InputManager.ActiveDevice;
        force = inputDevice.RightTrigger;
		var dir = inputDevice.RightBumper ? 1:-1;

        rb.AddTorque(Vector3.forward * force * dir , mode);
		rb.AddForce(Vector3.forward * 2 * inputDevice.RightStick.Y, mode);

		
		print("before: " + transform.localPosition.z);
		if(transform.localPosition.z > maxZ){
			print("maior");
			transform.localPosition =  new Vector3(cPos.x, cPos.y, maxZ);
		}
		if(transform.localPosition.z < minZ){
			transform.localPosition = new Vector3(cPos.x, cPos.y, minZ);
		}
		print("after: " + transform.localPosition.z);
		
	}

	void OnMouseDown(){
        
        
        
	}
}
