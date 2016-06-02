using UnityEngine;
using System.Collections;



public enum RollType { Roll};

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class MoveOnAxis : MonoBehaviour {

    // Movement variables
    public string m_horizontalAxis = "Horizontal";
    public string m_verticalAxis = "Vertical";
    public string m_RollAxis = "Dodge";
    public float m_maxSpeed = 3.0f;
    public float m_speed = 1.0f;
    public float m_friction = 0.8f;
   
    //roll variables
    public RollType m_rollType = RollType.Roll;
    public bool m_roll = false;
    public float m_rollForce = 50f;
    public float m_rollCooldown = 4.0f;
    public bool m_canRoll = true;
    public bool m_immune = false;

    //Component variables
    Animator m_anim;
    Rigidbody2D m_rb2d;

    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_rb2d = GetComponent<Rigidbody2D>();
    }
	// Update is called once per frame
	void Update () {
       
    }

    void FixedUpdate()
    {
        if (!m_roll)
        {
            Vector2 easeVelocity = m_rb2d.velocity;
            easeVelocity *= m_friction;
            m_rb2d.velocity = easeVelocity;

            Vector2 movement = (Vector2.right * Input.GetAxis(m_horizontalAxis) + Vector2.up * Input.GetAxis(m_verticalAxis)) * m_speed;
            m_rb2d.AddForce(movement);

            if (movement.sqrMagnitude > 0)
            {
                m_anim.SetBool("Moving", true);
            }
            else
            {
                m_anim.SetBool("Moving", false);
            }

            m_rb2d.velocity = new Vector2(Mathf.Clamp(m_rb2d.velocity.x, -m_maxSpeed, m_maxSpeed),
                                          Mathf.Clamp(m_rb2d.velocity.y, -m_maxSpeed, m_maxSpeed));

            
        }
    }

    public void Roll()
    {
        m_roll = true;
        m_anim.SetTrigger("Roll");
        m_rb2d.AddForce(m_rb2d.velocity.normalized * m_rollForce);
        StartCoroutine(RollCooldown());
    }

    IEnumerator RollCooldown() 
    {
        m_canRoll = false;
        while(m_roll)
        {
         yield return null;
        }
        
        yield return new WaitForSeconds(m_rollCooldown);
        m_canRoll = true;
    }
}
