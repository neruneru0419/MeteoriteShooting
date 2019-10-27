using System.Collections;
using UnityEngine;

public class EnemyBossBulletController : MonoBehaviour
{
    public float sin;
	public float cos;

	public int angle;

	public int rockangle;
	void Start(){
		rockangle = (int)((Random.value * 1000000) % 3);
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
		sin = (GameObject.Find("Canvas").GetComponent<UIController>().GetSin(angle)) / 10;
		cos = (GameObject.Find("Canvas").GetComponent<UIController>().GetCos(angle)) / 10;
		if (GameObject.Find("Canvas").GetComponent<UIController>().GetDifficulty() == 3){
			transform.Translate (cos * Time.timeScale, sin * Time.timeScale, 0);
		}
		else{
			transform.Translate ((0), (-0.1f)*Time.timeScale, 0);
		}
		if (transform.position.y < -5 || transform.position.y > 6) {
			Destroy (gameObject);
		}
		
	}
}
