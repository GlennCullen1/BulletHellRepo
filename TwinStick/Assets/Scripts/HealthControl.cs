using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthControl : MonoBehaviour {

	public Image healthBar;
	public float health; //between 0 - 100


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		checkHealth ();
	
	}

	void checkHealth (){
		healthBar.rectTransform.localScale = new Vector3 (health / 100, healthBar.rectTransform.localScale.y, healthBar.rectTransform.localScale.z);
		/*if(health <= 0.0f){
		
		}*/
	}

	void OnCollisionEnter2D (Collision2D other) {
		if (other.collider.CompareTag ("Bullet")) {
			SubtractHealth (10.0f);
		}
	}

	public void SubtractHealth(float amount){
		if (health - amount < 0.0f) {
			health = 0.0f;
		} else {
			health -= amount;
		}
	}

}
