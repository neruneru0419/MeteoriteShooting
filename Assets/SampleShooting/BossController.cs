using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour {

	public GameObject explosionPrefab; 
	public GameObject enemyBulletPrefab; 
	public int bulletSpacing = 0;
	public int hp;
	public int cnt;
	public int rockangle;
	public int difficulty;

	public bool moveflg = true;

	float fallSpeed;
	float rotSpeed;
	

	void Start () {
		rockangle = 0;
		this.fallSpeed = 0.05f;
		this.rotSpeed = 5f + 3f * Random.value;
		difficulty = GameObject.Find("Canvas").GetComponent<UIController>().GetDifficulty();
		if (difficulty == 1){
			this.hp = 10000;
			this.cnt = 60;
		}
		if (difficulty == 2){
			this.hp = 15000;
			this.cnt = 30;
		}
		if (difficulty == 3){
			this.hp = 20000;
			this.cnt = 30;
		}
	}
	
	void Update () {
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
		float sin = (GameObject.Find("Canvas").GetComponent<UIController>().GetSin(angle)) / 20;
		float cos = (GameObject.Find("Canvas").GetComponent<UIController>().GetCos(angle)) / 20;
		Vector3 pos1 = this.transform.position;
		Vector3 pos2 = this.transform.position;
		Vector3 pos3 = this.transform.position;
		Vector3 pos6 = this.transform.position;
		Vector3 pos7 = this.transform.position;
		pos2.x -= 2f;
		pos3.x += 2f;
		pos6.x -= 4f;
		pos7.x += 4f;

		if (transform.position.y > 4.0f) {
		    transform.Translate( 0, -fallSpeed * Time.timeScale, 0, Space.World);
        }
		else{
			if (moveflg){
				transform.Translate(fallSpeed* Time.timeScale, 0, 0, Space.World);
			}
			else{
				transform.Translate(-fallSpeed*Time.timeScale, 0, 0, Space.World);
			}
			if (bulletSpacing % cnt == 0) {
			Instantiate (enemyBulletPrefab, pos1, Quaternion.identity);
			Instantiate (enemyBulletPrefab, pos2, Quaternion.identity);
			Instantiate (enemyBulletPrefab, pos3, Quaternion.identity);
			Instantiate (enemyBulletPrefab, pos6, Quaternion.identity);	
			Instantiate (enemyBulletPrefab, pos7, Quaternion.identity);
			}
		}
		transform.Rotate(0, 0, rotSpeed );
		if(transform.position.x >= 6){
				moveflg = false;
		}
		else if(transform.position.x <= -6){
			moveflg = true;
		}

		bulletSpacing++;
		rockangle++;
	}
	void OnTriggerEnter2D(Collider2D coll) {

		// 衝突したときにスコアを更新する
		if(coll.tag != "enemyBullet"){
			GameObject.Find("Canvas").GetComponent<UIController>().AddScore();
			hp -= 100;
			Destroy (coll.gameObject);
			if (hp == 0){
				GameObject.Find ("Canvas").GetComponent<UIController> ().displayChar("GameClear\nPress R key to retry");
				GameObject effect = Instantiate (explosionPrefab, transform.position, Quaternion.identity) as GameObject;
				Destroy(effect, 1.0f);	
				Destroy (gameObject);
			}
		}
	}
}