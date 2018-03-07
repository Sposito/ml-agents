using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class BarController : MonoBehaviour {
    Rigidbody rb;
	public ForceMode mode = ForceMode.Acceleration;
	public float force = 50;

	float translationInput = 0f;
	float rotationInput = 0f;
	bool clockWiseInput = true;

	public bool playerControllable = false;
	Vector3 cPos;
	public StdInput playerController;

	public float tForce = 10f;
	public float rForce = 1f;
	public float maxRot = 20f;

	void Start () {
		cPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
		rb = GetComponent<Rigidbody> ();
		rb.maxAngularVelocity = maxRot;
	}

	public void SetInputs(float rotation,float translation, bool clockwise){
		this.translationInput = translation;
		this.rotationInput = rotation;
		this.clockWiseInput = clockwise;
	}

	void FixedUpdate () {
		//rb.AddTorque(Vector3.forward*force,mode);
		var inputDevice = InputManager.ActiveDevice;
        force = inputDevice.RightTrigger;
		var dir = clockWiseInput ? 1:-1;

        rb.AddTorque(Vector3.forward * rotationInput * dir * rForce , mode);
		rb.AddForce(Vector3.forward * tForce * translationInput, mode);
	}

	void OnCollisionEnter(Collision col){
		//playerConytroller.Rumble(gameObject.GetInstanceID(),1f);
		print(gameObject.name);
		//playerController.Test();
	}
}
