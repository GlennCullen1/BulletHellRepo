﻿using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

    public string m_horizontalAxis = "Horizontal2";
    public string m_verticalAxis = "Vertical2";
    public string m_blockAxis = "Block";
    public Animator m_anim;

    public bool m_blocking = false;
    public float m_blockCooldown = 4.0f;
    public bool m_canBlock = true;
	public bool m_hasBlocked = false;

	public int m_id;
	// Use this for initialization
	void Start () {
        m_anim = GameObject.FindGameObjectWithTag("RedPlayer").GetComponent<Animator>();
		m_id =  GameObject.FindGameObjectWithTag("RedPlayer").GetComponent<CharacterRecord>().m_TeamID;
	}
	
	// Update is called once per frame
	void Update () {
        // We are going to read the input every frame
        //Vector3 vNewInput = new Vector3(Input.GetAxis("Horizontal2"), Input.GetAxis(m_ControllerType + name + "RightStickY"), 0.0f);


        //transform.parent.rotation = Quaternion.Euler(0, 0, 0);
        float angle;

       	 angle = Mathf.Atan2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2")) * Mathf.Rad2Deg;
     

        // Apply the transform to the 
		if(Input.GetAxis("Horizontal2")!=0 || Input.GetAxis("Vertical2")!=0 )
		{
        transform.parent.rotation = Quaternion.Euler(0, 0, -angle);
        //transform.LookAt(transform.parent.position);
		}
			
        if (Input.GetAxis(m_blockAxis) > 0 && m_canBlock)
        {
            ActivateBlock();
        }
	}

    void ActivateBlock()
    {
		m_hasBlocked = false;
        m_anim.SetTrigger("Block");
        StartCoroutine(BlockCooldown());       
    }

    IEnumerator BlockCooldown()
    {
        m_canBlock = false;
        while (m_blocking)
        {
            yield return null;
        }

        yield return new WaitForSeconds(m_blockCooldown);
        m_canBlock = true;
    }
}
