using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	int score = 0;
	int difficulty = 0;
	float sin;
	float cos;
	string sceneName;
	GameObject scoreText;
	GameObject gameOverText;
	bool dispflg = true;
	public void GameOver(){
		this.gameOverText.GetComponent<Text>().text = "GameOver";
	}
	public void GameClear(){
		this.gameOverText.GetComponent<Text>().text = "GameClear";
	}
	public void displayChar(string moji){
		this.gameOverText.GetComponent<Text>().text = moji;
	}

	public void AddScore(){
		this.score += 10;
	}

	public void BreakScore(){
		this.score += 50;
	}

	public int GetScore(){
		return this.score;
	}
	public float GetSin(int get_angle){
		sin = Mathf.Sin(get_angle * (Mathf.PI / 180));
		return sin;
	}
	public float GetCos(int get_angle){
		cos = Mathf.Cos(get_angle * (Mathf.PI / 180));
		return cos;
	}
	public int GetDifficulty(){
		return difficulty;
	}
	// Use this for initialization
	void Start () {
		this.scoreText = GameObject.Find ("Score");
		this.gameOverText = GameObject.Find ("GameOver");
		this.sceneName = SceneManager.GetActiveScene ().name;
		Time.timeScale = 0;
	}

	void Update () {
		if (Time.timeScale == 0){
			displayChar("GameStart\nPress the 1 key -> easy play\n Press the 2 key -> normal play\nPress the 3 key -> hard play");
		}
		else{
			if (dispflg){
				displayChar("");
				dispflg = false;
			}
		}
		if (difficulty == 0){
			scoreText.GetComponent<Text> ().text = "Score:" + score.ToString("D4");
		}
		else if (difficulty == 1){
			scoreText.GetComponent<Text> ().text = "Score:" + score.ToString("D4")+ "\nEasy";
		}
		else if (difficulty == 2){
			scoreText.GetComponent<Text> ().text = "Score:" + score.ToString("D4")+ "\nNormal";
		}
		else if (difficulty == 3){
			scoreText.GetComponent<Text> ().text = "Score:" + score.ToString("D4") + "\nHard";
		}

		if (Input.GetKey (KeyCode.R)){
			SceneManager.LoadScene (sceneName);
		}
		if (Input.GetKey (KeyCode.Alpha1) && Time.timeScale == 0){
			Time.timeScale = 1;
			difficulty = 1;
		}
		else if (Input.GetKey (KeyCode.Alpha2) && Time.timeScale == 0){
			Time.timeScale = 1;
			difficulty = 2;
		}
		else if (Input.GetKey (KeyCode.Alpha3) && Time.timeScale == 0){
			Time.timeScale = 1;
			difficulty = 3;
		}
	}
}