using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthControl : MonoBehaviour {

    public CharacterRecord m_Record;
	public GameObject m_HealthBar;
	//public float health;


	// Use this for initialization
	void Start () {

        m_Record = gameObject.GetComponent<CharacterRecord>();
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
        float myHealth = (float)m_Record.m_CurrentHealth / (float)m_Record.m_MaxHealth;
        m_HealthBar.transform.localScale = new Vector3(Mathf.Clamp(myHealth, 0f, 1f), m_HealthBar.transform.localScale.y, m_HealthBar.transform.localScale.z);
		}


    void Hit(int damage)
    {
        SetHealthBar();
    }

}
