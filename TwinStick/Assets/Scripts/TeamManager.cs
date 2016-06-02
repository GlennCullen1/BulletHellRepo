using UnityEngine;
using System.Collections;

public class TeamManager : MonoBehaviour {

    public GameObject[][] m_TeamLists;
	// Use this for initialization
	void Start () {
		m_TeamLists = new GameObject[2][];
        m_TeamLists[0] = GameObject.FindGameObjectsWithTag("RedPlayer");
        m_TeamLists[1] = GameObject.FindGameObjectsWithTag("BluePlayer");
		Debug.Log("Test");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
