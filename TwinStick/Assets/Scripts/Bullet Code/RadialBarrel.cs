using UnityEngine;
using System.Collections;

public class RadialBarrel : MonoBehaviour {


    public GameObject m_Bullet;
    public float m_PulsePerSecond = 1.0f;
    public int m_NumberOfBullets = 10;
    float m_Timer = 0f;
    int m_ShotsFired = 0;

    public int[] Pattern;
    public int m_PatternCnt = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        m_Timer += Time.deltaTime;
        float angle = 0;

        if (m_Timer >= 1 / m_PulsePerSecond)
        {
            if (Pattern.Length > 0)
            {
                if (m_PatternCnt < Pattern.Length-1)
                {
                    m_PatternCnt++;
                }
                else
                {
                    m_PatternCnt = 0;
                }
                m_NumberOfBullets = Pattern[m_PatternCnt];
            }
           
            angle = 360 / m_NumberOfBullets; 
                

            for (int cnt = 0; cnt < m_NumberOfBullets; cnt++ )
            {
                GameObject bullet = (GameObject)Instantiate(m_Bullet, transform.position, Quaternion.identity);

                float theta = Mathf.Deg2Rad*(angle*cnt);

                // rotate foward vector of the bullet by theta
                Vector3 rotatedVect = new Vector3((transform.up.x * Mathf.Cos(theta)) - (transform.up.z * Mathf.Sin(theta)),
                                                   (transform.up.x * Mathf.Sin(theta)) + (transform.up.z * Mathf.Cos(theta)),
                                                    0);
                                                
               
               // rotatedVect = rotatedVect.normalized;
                Debug.DrawRay(transform.position, rotatedVect);
                bullet.transform.up = rotatedVect;
            }

                m_Timer = 0;
        }
	}
}
