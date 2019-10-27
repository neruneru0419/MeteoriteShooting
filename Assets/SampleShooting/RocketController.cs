using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour {

	public GameObject explosionPrefab; 
	public GameObject bulletPrefab;
	public int cnt = 0;
	public float speed = 0.1f;
	//Vector3[] pos;
	void Update () {
		//for (int i = 0; i < 5; i++){
		Vector3 pos1 = this.transform.position;
		Vector3 pos2 = this.transform.position;
		Vector3 pos3 = this.transform.position;
		pos2.x -= 0.5f;
		pos3.x += 0.5f;
		//}
		if (Input.GetKey(KeyCode.LeftShift)){
			speed = 0.05f;
		}
		else{
			speed = 0.1f;
		}
		if (Input.GetKey (KeyCode.LeftArrow) && -8 < this.transform.position.x) {
			transform.Translate (-speed * Time.timeScale, 0, 0);
		}
		if (Input.GetKey (KeyCode.RightArrow) && 8 > this.transform.position.x) {
			transform.Translate (speed * Time.timeScale, 0, 0);
		}

		if (Input.GetKey (KeyCode.UpArrow) && 10 > this.transform.position.y) {
			transform.Translate (0, speed * Time.timeScale, 0);
		}
		if (Input.GetKey (KeyCode.DownArrow) && -4 < this.transform.position.y) {
			transform.Translate (0, -speed * Time.timeScale, 0);
		}
		cnt += 1;
		if (Input.GetKey (KeyCode.Z) && cnt % 10 == 0 && Time.timeScale == 1){
			Instantiate (bulletPrefab, pos1, Quaternion.identity);
			Instantiate (bulletPrefab, pos2, Quaternion.identity);
			Instantiate (bulletPrefab, pos3, Quaternion.identity);
		}

	}
	void OnTriggerEnter2D(Collider2D coll) {

		// 衝突したときにスコアを更新する
		if(coll.tag == "enemyBullet" || coll.tag == "rock"){
			GameObject.Find ("Canvas").GetComponent<UIController> ().displayChar("GameOver\nPress R key to retry");
			GameObject effect = Instantiate (explosionPrefab, transform.position, Quaternion.identity) as GameObject;
			Destroy(effect, 1.0f);
			Destroy (coll.gameObject);	
			Destroy (gameObject);
		}
	}
}