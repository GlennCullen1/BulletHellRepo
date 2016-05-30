using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthControl : MonoBehaviour {

	public float curHealth;
	public float maxHealth;
	public GameObject healthBar;
	//public float health;


	// Use this for initialization
	void Start () {

		curHealth = maxHealth;
		SetHealthBar ();
		//set current health to be = to max health
		// ensures that a player's health is full when they spawn
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*public void TakeDamage(float amount){
		curHealth -= amount;
		SetHealthBar ();
	}*/
	
	public void SetHealthBar(){
			float myHealth = curHealth / maxHealth;
			healthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth,0f ,1f), healthBar.transform.localScale.y, healthBar.transform.localScale.z);
		}




	void OnCollisionEnter2D (Collision2D other) {
		if (other.collider.CompareTag ("Bullet")) {
			SubtractHealth (10.0f);
		}
	}

	public void SubtractHealth(float amount){
		curHealth -= amount;
		SetHealthBar ();
	}

	/*public void SubtractHealth(float amount){
		if (health - amount < 0.0f) {
			health = 0.0f;
		} else {
			health -= amount;
		}
	}*/

}
