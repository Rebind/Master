using UnityEngine;
using System.Collections;

public class Climbable : MonoBehaviour {

	public float leftOffset;
	public float rightOffset;



	// Use this for initialization
	void Start () {
	}

	void OnTriggerStay2D(Collider2D other)
	{	
		if(other.CompareTag("Player")){
		if (other.GetComponent<LimbController>().hasSecondArm) {

			if (other.GetComponent<Controller2D> ().collisions.below == false || Input.GetKeyDown (KeyCode.UpArrow)) {
				other.GetComponent<Player> ().isClimbing = true;

				if (other.GetComponent<Player> ().facingRight) {
					other.transform.position = new Vector3 (this.transform.position.x - (leftOffset), other.transform.position.y);	

				} else {

					other.transform.position = new Vector3 (this.transform.position.x - (rightOffset), other.transform.position.y);	

				}
			}

		} else {
			other.GetComponent<Player> ().isClimbing = false;

		}


	}
	}




	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag ("Player") && other.GetComponent<LimbController>().hasSecondArm) {
			other.GetComponent<Player> ().isClimbing = false;
		}


	}
}
