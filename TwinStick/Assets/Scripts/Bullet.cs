using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public float m_Speed = 10;
    public float m_Range = 50;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, m_Range / m_Speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * -(m_Speed * Time.deltaTime);
    }

    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (!coll.gameObject.GetComponent<MoveOnAxis>().m_immune)
            {
                coll.gameObject.BroadcastMessage("Hit");
                Destroy(gameObject);
            }
        }
    }
    

}
