using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFootBallAgent : Agent {
	public Rigidbody ball;
	public GameObject p1;
	public GameObject p2;

	public bool isPlayer1 = false;
	
	public override List<float> CollectState(){
        List<float> state = new List<float>();
//  	Ball states
		state.Add(ball.transform.position.x);
		state.Add(ball.transform.position.z);
		state.Add(ball.velocity.x);
		state.Add(ball.velocity.z);

		

//  	p1 info
		foreach (Rigidbody rb in p1.GetComponentsInChildren<Rigidbody>()){
			print(rb.gameObject.name);
			state.Add(rb.velocity.z);
			state.Add(rb.angularVelocity.z);
			state.Add(rb.transform.position.z);
			state.Add(rb.transform.rotation.ToEuler().z);
		}

//  	p2 info
		foreach (Rigidbody rb in p1.GetComponentsInChildren<Rigidbody>()){
			print(rb.gameObject.name);
			state.Add(rb.velocity.z);
			state.Add(rb.angularVelocity.z);
			state.Add(rb.transform.position.z);
			state.Add(rb.transform.rotation.eulerAngles.z);
		}

//  	padding for future reference
//  	TODO: after network is better trained is inteined
//  	to add here game score  delta and game points
//  	so network can rationalize strategies
		state.Add(0f); 
		state.Add(0f);
        return state;
    }

	public override void AgentStep(float[] act){
		
		reward = isPlayer1 ? 1 : -1 * (ball.transform.position.x  - ball.transform.position.z) ;
	}


}
