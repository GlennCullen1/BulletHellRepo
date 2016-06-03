using UnityEngine;
using System.Collections;

public class Cricketer : GenericCharacter {

    public MoveOnAxis m_MovementControler;
    public Block m_BlockControler;
	public CharacterInfo m_Character;

	public GameObject m_WicketObject;
    public GameObject m_UltWicketObject;
    private GameObject m_InstatiatedWicket;
    bool m_CanPlaceWicket = true;
    public int m_UltDuration = 10;
    bool m_IsUlting;

    int m_teamID;
	// Use this for initialization
	void Start () {
        m_MovementControler = gameObject.GetComponent<MoveOnAxis>();
        m_BlockControler = gameObject.GetComponentInChildren<Block>();
        m_UltResources = 100;
        m_CanUltimate = true;
        m_teamID = GetComponent<CharacterRecord>().m_TeamID;
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
        if (Input.GetButtonDown("Ultimate"))
        {
            Ultimate();
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
            if (!m_IsUlting)
            {
                m_InstatiatedWicket = (GameObject)Instantiate(m_WicketObject, m_BlockControler.gameObject.transform.position, Quaternion.identity);
               
            }
            else
            {
                m_InstatiatedWicket = (GameObject)Instantiate(m_UltWicketObject, m_BlockControler.gameObject.transform.position, Quaternion.identity);
            }
            m_InstatiatedWicket.GetComponent<ReflectProfile>().m_TeamID = m_teamID;
            StartCoroutine(SupportCooldown());
        }
    }

    public override void Ultimate()
    {
        if(CanUltimate())
        {
            StartCoroutine(UltimateRoutine());
        }
    }

    IEnumerator SupportCooldown()
    {
        m_CanPlaceWicket = false;
        yield return new WaitForSeconds(m_SupportCooldown);
        m_CanPlaceWicket = true;
    }

    IEnumerator UltimateRoutine()
    {
        float oldBulletVel;
        int oldTeamVal;

        m_IsUlting = true;
        m_CanUltimate = false;
        if (m_InstatiatedWicket) //if we have a wicket upgrade it with a new one
        {
            GameObject newWicket = (GameObject)Instantiate(m_UltWicketObject, m_InstatiatedWicket.transform.position, Quaternion.identity);
            Destroy(m_InstatiatedWicket);
            m_InstatiatedWicket = newWicket;
        }

        //delete old block profile, add new one
        ReflectProfile prof = transform.root.GetComponentInChildren<ReflectProfile>();
        oldBulletVel = prof.m_VelocityScale;
        oldTeamVal = prof.m_TeamID;
        GameObject block = prof.gameObject;
        Destroy(prof);
        prof = block.AddComponent<HomingReflect>();
        prof.m_TeamID = oldTeamVal;
        prof.m_VelocityScale = oldTeamVal;
        
        yield return new WaitForSeconds(m_UltDuration);

        //delete new block profile add old one
        Destroy(prof);
        prof = block.AddComponent<BasicReflectProfile>();
        prof.m_TeamID = oldTeamVal;
        prof.m_VelocityScale = oldTeamVal;
        m_IsUlting = false;
        m_CanUltimate = true;
    }

    public override bool CanUltimate()
    {
        if (m_CanUltimate && m_UltResources>= m_ResourcesToUlt)
        {
            return true;
        }
        return false;
    }
}
