using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {


	public float sin;
	public float cos;
	
	void Update () {

		transform.Translate (0, 0.3f*Time.timeScale, 0);

		if (transform.position.y > 5) {
			Destroy (gameObject);
		}
	}
}