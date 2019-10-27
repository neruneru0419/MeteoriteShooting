using UnityEngine;
using System.Collections;

public class RockController : MonoBehaviour {

	public GameObject explosionPrefab; 
	public GameObject enemyBulletPrefab; 
	public int bulletSpacing = 0;
	public int hp;

	public int spacingCnt;
	public int hitCount = 0;
	//float fallSpeed;
	float rotSpeed;
	bool shotflg = true;	

	void Start () {

		//this.fallSpeed = 0.03f;
		if (GameObject.Find("Canvas").GetComponent<UIController>().GetDifficulty() == 1){
			spacingCnt = 15;
			hp = 600;
		}
		else if (GameObject.Find("Canvas").GetComponent<UIController>().GetDifficulty() == 2){
			spacingCnt = 30;
			hp = 1200;
		} 
		else if (GameObject.Find("Canvas").GetComponent<UIController>().GetDifficulty() == 3){
			spacingCnt = 45;
			hp = 1200;
		} 
		this.rotSpeed = 5f + 3f * Random.value;
	}
	
	void Update () {
		int rockangle = (int)((rotSpeed * 1000000) % 3);
		int angle = 0;
		if (rockangle == 0){
			angle = 240;
		} 
		else if(rockangle == 1){
			angle = 270;
		}
		else if(rockangle == 2){
			angle = 300;
		} 
		float sin = GameObject.Find("Canvas").GetComponent<UIController>().GetSin(angle);
		float cos = GameObject.Find("Canvas").GetComponent<UIController>().GetCos(angle);
		//transform.Translate( 0, -fallSpeed, 0, Space.World);
		transform.Translate((cos / 20)*Time.timeScale, (sin / 20)*Time.timeScale, 0, Space.World);
		transform.Rotate(0, 0, rotSpeed * Time.timeScale);
		hitCount = GameObject.Find("Canvas").GetComponent<UIController>().GetScore();
		if (transform.position.y < -5.5f) {
			Destroy (gameObject);
		}
		if (bulletSpacing % 15 == 0 && shotflg) {
			Instantiate (enemyBulletPrefab, transform.position, Quaternion.identity);
			if (bulletSpacing == spacingCnt){
				shotflg = false;
			}
		}
		if (GameObject.Find("Canvas").GetComponent<UIController>().GetDifficulty() == 1){
			if (hitCount >= 5000){
				for (int i = 0; i < 3; i++){
					GameObject effect = Instantiate (explosionPrefab, transform.position, Quaternion.identity) as GameObject;
					Destroy(effect, 5.0f);	
					Destroy (gameObject);
				}
			}
		}
		else{
			if (hitCount >= 10000){
				for (int i = 0; i < 3; i++){
					GameObject effect = Instantiate (explosionPrefab, transform.position, Quaternion.identity) as GameObject;
					Destroy(effect, 5.0f);	
					Destroy (gameObject);
				}
			}
		}
		bulletSpacing++;
	}
	void OnTriggerEnter2D(Collider2D coll) {

		// 衝突したときにスコアを更新する
		if(coll.tag == "bullet"){
			GameObject.Find("Canvas").GetComponent<UIController>().AddScore();
			hp -= 100;
			Destroy (coll.gameObject);
			if (hp == 0){
				GameObject effect = Instantiate (explosionPrefab, transform.position, Quaternion.identity) as GameObject;
				Destroy(effect, 1.0f);	
				Destroy (gameObject);
				GameObject.Find("Canvas").GetComponent<UIController>().BreakScore();
			}
		}
	}
}