using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI timer;

	public LifePanel lifePanel;
	public static GameController instance;

	public string currentScene;
	public string nextScene;

	int score;
	int minScore;
	int maxScore;
	int life;
	public float Countdown;
	void Awake(){
		instance = this;
	}

	void Start () {
		
		score = 0;
		minScore = 0;
		maxScore = 100;
		// timer.text = Countdown.ToString("");
		scoreText.text = score.ToString ("");
		life = 3;
	
	}

	void Update(){
		Countdown -= Time.deltaTime;
		timer.text = Countdown.ToString("00.00");
		if(life <= 0 || Countdown <= 0) {
			ChangeScene (currentScene);
		}

		lifePanel.UpdateLife (life);

		if (life > 0 && score >= 1000){}
			ChangeScene (nextScene);

	}

	void ChangeScene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}

	void showScore(){
		scoreText.text = score.ToString ("0");
	}

	public void AddScore(int ballScore){
		if(ballScore < 0 )
		{
			life -= 1;
		}
		score += ballScore;
		Debug.Log(score);
		showScore ();
	}
}
