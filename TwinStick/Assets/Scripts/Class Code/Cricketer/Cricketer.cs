using UnityEngine;
using System.Collections;

public class Cricketer : GenericCharacter {

    public MoveOnAxis m_MovementControler;
    public Block m_BlockControler;
    public GameObject m_WicketObject;

    private GameObject m_InstatiatedWicket;
    bool m_CanPlaceWicket = true;
	// Use this for initialization
	void Start () {
        m_MovementControler = gameObject.GetComponent<MoveOnAxis>();
        m_BlockControler = gameObject.GetComponentInChildren<Block>();
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("Dash") > 0 && m_MovementControler.m_canRoll)
        {
            Dash();
        }
        if (Input.GetAxis("Block") > 0 && m_BlockControler.m_canBlock)
        {
            Block();
        }
        if (Input.GetButtonDown("Support"))
        {
            Support();
        }
	}

    public override void Dash()
    {
        //ToDo: MOVE ROLL METHOD TO THIS DASH AND OUT OF GENERIC MOVEMENT CONTROLER
        m_MovementControler.Roll();
    }
    public override void Block()
    {
        //ToDo: MOVE BLOCK METHOD TO THIS DASH AND OUT OF GENERIC BLOCK CONTROLER
        m_BlockControler.ActivateBlock();
    }
    public override void Support()
    {
        if (m_CanPlaceWicket)
        {
            m_InstatiatedWicket = (GameObject)Instantiate(m_WicketObject, m_BlockControler.gameObject.transform.position, Quaternion.identity);
            StartCoroutine(SupportCooldown());
        }
    }
    public override void Ultimate()
    {

    }

    IEnumerator SupportCooldown()
    {
        m_CanPlaceWicket = false;
        yield return new WaitForSeconds(m_SupportCooldown);
        m_CanPlaceWicket = true;
    }
}
