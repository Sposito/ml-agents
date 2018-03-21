using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableFootBallAgent : Agent {
	public Rigidbody ball;
	public GameObject p1;
	public GameObject p2;

	public GameManager gameManager;
	int lastScore = 0;
	int lastAdversaryScore = 0;

	public bool isPlayer1 = false;
	public StdInput stdInput;
	
	public override List<float> CollectState(){
		float multiplier = isPlayer1 ? 1f : -1f;
        List<float> state = new List<float>();
//  	Ball states
		state.Add(ball.transform.localPosition.x * multiplier);
		state.Add(ball.transform.localPosition.z);
		state.Add(ball.velocity.x * multiplier);
		state.Add(ball.velocity.z);
//  	p1 info
		foreach (Rigidbody rb in p1.GetComponentsInChildren<Rigidbody>()){
//			print(rb.gameObject.name);
			state.Add(rb.velocity.z);
			state.Add(rb.angularVelocity.z);
			state.Add(rb.transform.localPosition.z);
			state.Add(rb.transform.rotation.eulerAngles.z);
		}
//  	p2 info
		foreach (Rigidbody rb in p1.GetComponentsInChildren<Rigidbody>()){
		//	print(rb.gameObject.name);
			state.Add(rb.velocity.z);
			state.Add(rb.angularVelocity.z);
			state.Add(rb.transform.localPosition.z);
			state.Add(rb.transform.rotation.eulerAngles.z);
		}
//  	padding for future reference
//  	TODO: after network is better trained is inteined to add here game score  delta and game points so network can rationalize strategies
		state.Add(0f); 
		state.Add(0f);
		//print(state.Count);
        return state;
    }

	public override void AgentStep(float[] act){
		stdInput.inputArray = act;
		//print(act.Length);
		reward = (isPlayer1 ? 1 : -1) * (ball.transform.localPosition.x  - ball.transform.localPosition.z) ;
		
		//This loops tries to teach the network that inputs higher than 1 are useless and are a waste of "energy"
		foreach (float f in act){
			reward -= Mathf.Abs(f) > 1? 0.01f : 0f;
		}

		if (isPlayer1){
			if(gameManager.p1Score > lastScore){
				lastScore = gameManager.p1Score;
				reward += 1f;	
			}
			if(gameManager.p2Score > lastAdversaryScore){
				lastAdversaryScore = gameManager.p2Score;
				reward -= 1f;
			}
			
		}
		else{
			if(gameManager.p2Score > lastScore){
				lastScore = gameManager.p2Score;
				reward += 1f;
				done = true;	
			}
			if(gameManager.p1Score > lastAdversaryScore){
				lastAdversaryScore = gameManager.p1Score;
				reward -= 1f;
				done = true;
			}
			
		}
	}

	 public override void AgentReset(){
       
    }


}
