using UnityEngine;
using System.Collections;

public class Climbable : MonoBehaviour {

	public float offset;


	// Use this for initialization
	void Start () {

	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag ("Player") && other.GetComponent<LimbController>().hasSecondArm) {
				
			if (other.GetComponent<Controller2D> ().collisions.below == false || Input.GetKeyDown(KeyCode.UpArrow)) {
				other.GetComponent<Player> ().isClimbing = true;
				other.transform.position = new Vector3 (this.transform.position.x-offset, other.transform.position.y);
				other.GetComponent<Player> ().faceRight();

			} else {
				other.GetComponent<Player> ().isClimbing = false;

			}
				
			
		}

		Debug.Log ("on ladder");
	}


	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag ("Player") && other.GetComponent<LimbController>().hasSecondArm) {
			other.GetComponent<Player> ().isClimbing = false;
		}

		Debug.Log ("off ladder");
	}
}
