using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
using XInputDotNetPure;

public class StdInput : MonoBehaviour {

	
	public BarController[] controllers;
	BarController hand1;
	BarController hand2;

	
	int hand1index = 0;
	int unusedHand = 1;
	int hand2index = 2;

	public bool manual = false;

	void Start () {
		for(int i = 0; i < 3; i++){
			controllers[i].playerController = this;
		}
		hand1 = controllers[hand1index];
		hand2 = controllers[hand2index];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		ManualController();	
		
	}

	void ManualController(){
		var inputDevice = InputManager.ActiveDevice;
	
		if (inputDevice.DPadRight){
			hand2.SetInputs(0f, 0f, true);
			hand2 = controllers[unusedHand];
			var temp = unusedHand;
			unusedHand = hand2index;
			hand2index = temp;
			GamePad.SetVibration((XInputDotNetPure.PlayerIndex)0, 1f, 1f);
			
			
		}

		if (inputDevice.DPadLeft){
			hand1.SetInputs(0f, 0f, true);
			hand1 = controllers[unusedHand];
			var temp = unusedHand;
			unusedHand = hand1index;
			hand1index = temp;
			
			print(inputDevice.DPadRight);
		}

		//enforces that right Hand always hand 2

		if(hand2index < hand1index ){
			var temp = hand2index;
			hand2index = hand1index;
			hand1index = temp;
			hand1 = controllers[hand1index];
			hand2 = controllers[hand2index];
		}

		hand1.SetInputs(inputDevice.LeftTrigger, inputDevice.LeftStick.Y, inputDevice.LeftBumper);
		hand2.SetInputs(inputDevice.RightTrigger, inputDevice.RightStick.Y, inputDevice.RightBumper);
    
	}

	public IEnumerator Rumble(int id, float intencity){
		if (!manual)
			yield return null;

		float intensityL = 0f;
		float intensityR = 0f;
			if(id == hand1.GetInstanceID()){
				intensityL = intencity;
			}

			if(id == hand2.GetInstanceID()){
				intensityR = intencity;
			}

			while(intensityL > 0f && intensityR > 0){
				intensityL -= 0.03f;
				intensityR -= 0.03f;
				GamePad.SetVibration((PlayerIndex)0, intensityL, intensityR);
				yield return new WaitForEndOfFrame();
			}	
	}

	public void Test(){
		print("Test");
	}

}
