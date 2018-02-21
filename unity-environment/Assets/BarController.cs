using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class BarController : MonoBehaviour {
    Rigidbody rb;
	public ForceMode mode = ForceMode.Acceleration;
	public float force = 50;

	public bool playerControllable = false;
	Vector3 cPos;

	void Start () {
		cPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
		rb = GetComponent<Rigidbody> ();
		rb.maxAngularVelocity = 200f;
	}

	void FixedUpdate () {
		//rb.AddTorque(Vector3.forward*force,mode);
		if (!playerControllable)
			return;

        var inputDevice = InputManager.ActiveDevice;
        force = inputDevice.RightTrigger;
		var dir = inputDevice.RightBumper ? 1:-1;

        rb.AddTorque(Vector3.forward * force * dir , mode);
		rb.AddForce(Vector3.forward * 1 * inputDevice.RightStick.Y, mode);
	}
}
