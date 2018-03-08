using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFootBallAgent : Agent {
	public Rigidbody ball;
	public Rigidbody p1;
	public Rigidbody p2;
	  public override List<float> CollectState()
    {
        List<float> state = new List<float>();
        //Ball states
		state.Add(ball.transform.position.x);
		state.Add(ball.transform.position.z);
		state.Add(ball.velocity.x);
		state.Add(ball.velocity.z);

		//p1 info
		state.Add(p1.velocity.z);
		state.Add(p1.angularVelocity.z);
		state.Add(p1.transform.position.z);
		state.Add(p1.transform.rotation.ToEuler().z);

		//p2 info
		state.Add(p2.velocity.z);
		state.Add(p2.angularVelocity.z);
		state.Add(p2.transform.position.z);
		state.Add(p2.transform.rotation.ToEuler().z);

		//  padding for future reference
		//* TODO: after network is better trained is inteined
		//* to add here game score  delta and game points
		//* so network can rationalize strategies

		state.Add(0f); 
		state.Add(0f);
		

        return state;
    }

}
