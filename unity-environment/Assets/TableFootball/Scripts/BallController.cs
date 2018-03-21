using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    Rigidbody rb;
	float idleTime = 0f;
	float maxIdleTime = 10f;
	Vector3 startPos;
	public GameManager manager;
	void Start () {
		rb = GetComponent<Rigidbody>();
		startPos = transform.position;
		PutBallInGame();
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity.sqrMagnitude < 0.01)
			idleTime += Time.deltaTime;
		else
			idleTime = 0;

		if(idleTime > maxIdleTime){
			rb.velocity = Vector3.zero;
			idleTime = 0f;
			StartCoroutine(WaitAndPutBallInGame(2f));
		}

		if (transform.position.y < -5){
			PutBallInGame();
		}

	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "P1Goal"){
			manager.p1Score++;
		}

		if (col.tag == "P2Goal"){
			manager.p2Score++;
		}
	}

	void PutBallInGame(){
		transform.position = startPos;
		float sign = Random.Range(1,3) == 1 ? -1f : 1f;
		Vector3 dir = (Vector3.forward * -3f / rb.mass) + Vector3.right * Random.Range(.3f, .75f) * sign / rb.mass; 
		rb.AddForce(dir);
	}

	IEnumerator WaitAndPutBallInGame(float time){
		yield return new WaitForSeconds(time);
		PutBallInGame();
	}	
}