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
	public Transform hpBar;
	public string currentScene;
	public string nextScene;

	int hp;
	int minHP;
	int maxHP;
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
		maxScore = 20;
		life =3;
		// timer.text = Countdown.ToString("");
		scoreText.text = score.ToString ("");
		hp = 30;
		minHP= 0;
		maxHP = 100;
	
	}

	void Update(){
		Countdown -= Time.deltaTime;
		timer.text = Countdown.ToString("00.00");
		if (hp > 20 && hp <= 30)
			life = 3;
		if (hp > 10 && hp <= 20)
			life = 2;
		else if (hp > 0 && hp <= 10)
			life = 1;
		else if (hp <= 0) {
			life = 0;
			ChangeScene (currentScene);
		}
		else if(Countdown <= 0)
		{
			ChangeScene(currentScene);
		}

		lifePanel.UpdateLife (life);
		if (hp > 0 && score >= maxScore){
			ChangeScene (nextScene);
		}
	}

	void ChangeScene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}

	void showScore(){
		scoreText.text = score.ToString ("0");
	}
	void showHP(){
		hpBar.transform.localScale = new Vector3 (hp / 100.0f, 1.0f, 1.0f);
	}

	public void AddScore(int ballScore){
		if(ballScore < 0 )
		{
			hp += ballScore;
		}
		score += ballScore;
		Debug.Log(score);
		showScore ();
		showHP();
	}
}
