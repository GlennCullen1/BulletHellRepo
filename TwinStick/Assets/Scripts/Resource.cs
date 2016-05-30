using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour {
	
	public GameObject Flag;
	public ScoreManager scoreManager;
	int resourceScore;
	public int baseWorth;
	public int bonusMultiplier;
	public float pointsRadius;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	//If Resource collides with player, give points to relevant team
	//On collision with player, if resource is within flagradius, award double points
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "RedPlayer"){
			GetFlagPythagoras ();
			scoreManager.Score(false, resourceScore);
			Destroy (gameObject);
		}else if (col.gameObject.tag == "BluePlayer"){
			GetFlagPythagoras ();
			scoreManager.Score(true, resourceScore);
			Destroy (gameObject);
		}
	}


	void GetFlagPythagoras(){
		float distance;
		if (Vector2.Distance (transform.position, Flag.transform.position) < pointsRadius){
			resourceScore = baseWorth*bonusMultiplier;
		} else {
			resourceScore = baseWorth;
		}
	}
}
