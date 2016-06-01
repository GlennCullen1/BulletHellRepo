using UnityEngine;
using System.Collections;

public class Wicket : MonoBehaviour {

    public int m_Charges = 3;
    public float m_Duration;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, m_Duration);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            m_Charges--;
            if (m_Charges == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
