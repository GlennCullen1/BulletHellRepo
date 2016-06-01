using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class Bullet : MonoBehaviour
{

    public float m_Speed = 10;
    public float m_Range = 50;
	public Vector2 m_velocity;

	public Sprite[] m_ColorTypes;
	public SpriteRenderer m_spriteRenderer;
	int m_ID = 0;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, m_Range / m_Speed);
		m_velocity = transform.up*-m_Speed;
		m_spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)(m_velocity * Time.deltaTime);
    }

    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "RedPlayer" || coll.gameObject.tag == "BluePlayer")
        {
			if (!coll.gameObject.GetComponent<MoveOnAxis>().m_immune && coll.gameObject.GetComponent<CharacterRecord>().m_TeamID != m_ID )
            {
                coll.gameObject.BroadcastMessage("Hit",(int)10);
                Destroy(gameObject);
            }
        }
        if (coll.gameObject.tag == "Barrier")
        {
            Reflect(coll.gameObject);
        }
    }

	void OnTriggerStay2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Barrier")
		{
			Block block = coll.gameObject.GetComponent<Block>();
            if (block)
            {
                if (block.m_blocking)
                {
                    // call reflect function. On completed version should be kept in block object for custom block behaviours
                    Reflect(coll.gameObject);
                    block.m_hasBlocked = true;
                }
            }
            else
            {
                Reflect(coll.gameObject);
            }
		}
	}
    
	void Reflect(GameObject Barrier)
	{
		//RaycastHit2D hit;
		//hit = Physics2D.Raycast(transform.position, (Barrier.transform.position - transform.position));
		//velocity =velocity -2* Vector2.Dot(velocity,hit.normal.normalized) * hit.normal.normalized-velocity;
        /*
		m_velocity = Barrier.transform.right.normalized * m_velocity.magnitude;
		SetID (Barrier.GetComponent<Block>().m_id);
		Debug.DrawRay(Barrier.transform.position,Barrier.transform.right);*/

        ReflectInfo reflectInfo = Barrier.GetComponent<ReflectProfile>().Reflect(gameObject);
        m_velocity = reflectInfo.ReflectVector * m_velocity.magnitude;
        SetID(reflectInfo.TeamId);

	}

	public void SetID(int id)
	{
		m_spriteRenderer.sprite = m_ColorTypes[id];
		m_ID = id;
	}


}
