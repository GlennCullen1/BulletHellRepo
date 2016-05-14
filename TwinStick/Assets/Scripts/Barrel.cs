using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour {

    public GameObject m_Bullet;
    public float m_BulletPerSecond = 1.0f;
    public int m_NumberOfBulletsPerMiss = 10;
    float m_Timer = 0f;
    int m_ShotsFired = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        m_Timer += Time.deltaTime;

        if(m_Timer >= 1/m_BulletPerSecond)
        {
            if(m_ShotsFired / m_NumberOfBulletsPerMiss == 1)
            {
                m_ShotsFired = 0;
            }
            else
            {
                Instantiate(m_Bullet, transform.position, transform.rotation);
                m_ShotsFired++;
            }
            
            m_Timer = 0;
        }
	}
}
