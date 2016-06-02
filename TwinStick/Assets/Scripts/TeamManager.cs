using UnityEngine;
using System.Collections;

public class TeamManager : MonoBehaviour {

    GameObject[][] m_TeamLists;
	// Use this for initialization
	void Start () {
        m_TeamLists[0] = GameObject.FindGameObjectsWithTag("RedPlayer");
        m_TeamLists[1] = GameObject.FindGameObjectsWithTag("BluePlayer");

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
