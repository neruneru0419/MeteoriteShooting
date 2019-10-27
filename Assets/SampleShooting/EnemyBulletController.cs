using System.Collections;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    public float sin;
	public float cos;
	public int hitCount = 0;
	public int score;
	public float bulletSpeed = -0.1f;
	public int angle;
	void Update () {
		angle = GameObject.Find("Canvas").GetComponent<UIController>().GetAngle();
		sin = GameObject.Find("Canvas").GetComponent<UIController>().GetSin(angle);
		cos = GameObject.Find("Canvas").GetComponent<UIController>().GetCos(angle);
		score = GameObject.Find("Canvas").GetComponent<UIController>().GetScore();
		hitCount = GameObject.Find("Canvas").GetComponent<UIController>().GetScore();
		/*
		if (score % 1000 == 0 && score != 0){
			bulletSpeed -= 0.2f;
		}*/
		transform.Translate (0, -0.1f*Time.timeScale, 0);

		if (transform.position.y < -5) {
			Destroy (gameObject);
		}
		if (GameObject.Find("Canvas").GetComponent<UIController>().GetDifficulty() == 1){
			if (hitCount >= 5000){
				Destroy (gameObject);
			}
		}
		else{
			if (hitCount >= 10000){
				Destroy (gameObject);
			}
		}
		
	}
}
