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

<<<<<<< HEAD
			if (Input.GetKeyDown (KeyCode.UpArrow) || (Input.GetAxisRaw("Vertical")>0)) {
=======
				if (Input.GetKeyDown (KeyCode.UpArrow) || (Input.GetAxisRaw("Vertical")>0)) {
>>>>>>> refs/remotes/origin/master
				other.GetComponent<Player> ().isClimbing = true;
			}

	}
			if (other.GetComponent<Player> ().facingRight && other.GetComponent<Player>().isClimbing) {
				other.transform.position = new Vector3 (this.transform.position.x - (leftOffset), other.transform.position.y);	

				Debug.Log ("Facing Right");

			} else if(!other.GetComponent<Player> ().facingRight && other.GetComponent<Player>().isClimbing){

				other.transform.position = new Vector3 (this.transform.position.x - (rightOffset), other.transform.position.y);	
				Debug.Log ("Not Facing Right");


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
