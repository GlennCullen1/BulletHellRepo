using UnityEngine;
using System.Collections;

public class TeamManager : MonoBehaviour {

    public GameObject[][] m_TeamLists;
	// Use this for initialization
	void Start () {
		m_TeamLists = new GameObject[2][];
        m_TeamLists[0] = GameObject.FindGameObjectsWithTag("BluePlayer");
        m_TeamLists[1] = GameObject.FindGameObjectsWithTag("Redlayer");
		Debug.Log("Test");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public GameObject FindClosestEnemy(GameObject origin, int EnemyTeamID, bool requireLOS)
    {
        return CommonMethods.FindClosestObjectInArray(origin, m_TeamLists[EnemyTeamID], requireLOS);
    }
}
