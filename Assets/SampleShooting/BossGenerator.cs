using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rockPrefab;
	public RockController rockController;

	public int scoreCount;

    public bool bossflg = true;

	void Start () {
		InvokeRepeating ("GenRock", 0, 1);
	}
	void Update(){
		scoreCount = GameObject.Find("Canvas").GetComponent<UIController>().GetScore();
	}
	void GenRock () {
		if (GameObject.Find("Canvas").GetComponent<UIController>().GetDifficulty() == 1){
			if (scoreCount >= 5000 && bossflg){
				Instantiate (rockPrefab, new Vector3 (1, 6, 0), Quaternion.identity);
				bossflg = false;
			}
		}
		else{
			if (scoreCount >= 10000 && bossflg){
				Instantiate (rockPrefab, new Vector3 (1, 6, 0), Quaternion.identity);
				bossflg = false;
			}
		}
	}
}
