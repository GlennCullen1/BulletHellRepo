using UnityEngine;
using System.Collections;

public class CharacterRecord : MonoBehaviour {

	public int m_TeamID = 1;
    public int m_MaxHealth = 100;
    public int m_CurrentHealth;
	// Use this for initialization
	void Start () {
        m_CurrentHealth = m_MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Hit(int damage)
    {
        Debug.Log("Hit!");
        m_CurrentHealth -= damage;
        Mathf.Clamp(m_CurrentHealth, 0, (float)m_MaxHealth);
    }
}
