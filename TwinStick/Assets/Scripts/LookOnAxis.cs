using UnityEngine;
using System.Collections;

public enum facing {North,South,East,West}

public class LookOnAxis : MonoBehaviour {

    public string m_horizontalAxis = "Horizontal2";
    public string m_verticalAxis = "Vertical2";
    public Animator m_anim;
    public facing m_facing;
	// Use this for initialization
	void Start () {
        m_anim = GetComponent<Animator>();
        m_facing = facing.South;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = (Vector3.right * Input.GetAxis(m_horizontalAxis) + Vector3.up * Input.GetAxis(m_verticalAxis));

        if(direction.x > 0 && direction.x > direction.y)
        {
            if(m_facing!= facing.East)
            {
                m_anim.SetTrigger("East");
            }

            m_facing = facing.East;
        }
        else if(direction.x < 0 && direction.x < direction.y)
        {
            if (m_facing != facing.West)
            {
                m_anim.SetTrigger("West");
            }

            m_facing = facing.West;
        }
        else if (direction.y > 0 && direction.y>direction.x)
        {
            if (m_facing != facing.North)
            {
                m_anim.SetTrigger("North");
            }

            m_facing = facing.North;
        }
        else if (direction.y < 0 && direction.y < direction.x)
        {
            if (m_facing != facing.South)
            {
                m_anim.SetTrigger("South");
            }

            m_facing = facing.South;
        }
	}
}
