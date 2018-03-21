using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {
    Rigidbody rb;
	public ForceMode mode = ForceMode.Acceleration;
	public float force = 20f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.maxAngularVelocity = 2000f;
	}
	
	// Update is called once per frame
	void Update () {
		//rb.AddTorque(Vector3.forward*force,mode);
	}

	void OnMouseDown(){
		rb.AddTorque(Vector3.forward*force,mode);

	}
}
