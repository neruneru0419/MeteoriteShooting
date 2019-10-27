using UnityEngine;
using System.Collections;

public class RockGenerator : MonoBehaviour {

	public GameObject enemy;
	public RockController rockController;

	public int scoreCount;
	public int shotCount = 0;
	public int difficulty;

	public float bulletSpacing;

	void Start () {
		bulletSpacing = 1.0f;
		InvokeRepeating ("GenRock", 0, bulletSpacing);
	}
	void Update(){
		scoreCount = GameObject.Find("Canvas").GetComponent<UIController>().GetScore();
		difficulty = GameObject.Find("Canvas").GetComponent<UIController>().GetDifficulty();

		Debug.Log(bulletSpacing);
		if (shotCount != scoreCount / 1000){
			if (difficulty == 1){
				bulletSpacing = bulletSpacing - 0.03f;
			}
			if (difficulty == 2){
				bulletSpacing = bulletSpacing - 0.05f;
			}
			if (difficulty == 3){
				bulletSpacing = bulletSpacing - 0.1f;
			}
			Debug.Log(bulletSpacing);
			shotCount = scoreCount / 1000;
			CancelInvoke();
			InvokeRepeating ("GenRock", 0, bulletSpacing);
		}
	}
	void GenRock () {
		if (GameObject.Find("Canvas").GetComponent<UIController>().GetDifficulty() == 1){
			if (scoreCount < 5000){
				Instantiate (enemy, new Vector3 (-6f + 10 * Random.value, 6, 0), Quaternion.identity);
			}
		}
		else{
			if (scoreCount < 10000){
				Instantiate (enemy, new Vector3 (-6f + 10 * Random.value, 6, 0), Quaternion.identity);
			}
		}
	}
}