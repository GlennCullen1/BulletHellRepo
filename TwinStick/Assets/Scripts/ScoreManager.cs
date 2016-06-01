using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	
	public int blueScore;
	public int redScore;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//Add points to the relevant score
	public void Score(bool isBlue, int amount){
		if (isBlue == false) {
			redScore=redScore+amount;
		} else {
			blueScore=blueScore+amount;
		}
	}
}
