using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

	private int _p1Score = 0;
	private int _p2Score = 0;
	public float gameTime = 0f;


	
	public Text p1ScoreText;
	public Text p2ScoreText;
	public Text timerText;
	public bool training = true;

	public int p1Score{
		get{
			return _p1Score;
		}
		set{
			_p1Score = value;
			if(!training)
				p1ScoreText.text = _p1Score.ToString();
		}
	}

	public int p2Score{
		get{
			return _p2Score;
		}
		set{
			_p2Score = value;
			if(!training)
				p2ScoreText.text = _p2Score.ToString();
		}
	}
	
	void Start () {
		if(!training)
			StartCoroutine( TimeUpdater() );
	}
	
	// Update is called once per frame
	void Update () {
		gameTime += Time.deltaTime;

	}

	
	public IEnumerator TimeUpdater(){
		int seconds = Mathf.FloorToInt(gameTime);
		
		while(true){
			seconds = Mathf.FloorToInt(gameTime);
			timerText.text = string.Format("{0}:{1, 0:D2}", seconds /60, seconds % 60) ;
			yield return new WaitForSeconds(1f);
		}
	}
}
