/// <summary>
/// Flag.
/// </summary>
using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {
	
	private bool isCarried;
	public Vector3 spawnPos;
	public ScoreManager scoreManager;
	public int flagScore;
	
	// Use this for initialization
	void Start () {
		spawnPos = transform.position;
		flagScore = 10;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//On Collision with Player, parent the bullet to the player
	void OnTriggerEnter2D(Collider2D col){
		if ((col.gameObject.tag == "BluePlayer") || (col.gameObject.tag == "RedPlayer")){
			transform.parent = col.gameObject.transform;
		}
		
		//If the goal is entered by the flag, run the relevant score method and decide if it is blue or not
		if (col.gameObject.tag == "Goal"){
			if(col.gameObject.name == "RedGoal"){
				scoreManager.Score(false, flagScore);
			}else{
				scoreManager.Score(true, flagScore);
			}
			
			transform.position = spawnPos;
			transform.parent = null;
		}
	}
}
