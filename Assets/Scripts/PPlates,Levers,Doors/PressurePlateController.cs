using UnityEngine;
using System.Collections;

public class PressurePlateController : MonoBehaviour {

	BoxCollider2D myCollider;


	public bool moveDoor;
	public bool movePlatform;

	public GameObject[] affectedDoors;
	public GameObject[] affectedPlatforms;

	private bool facingRight;


	bool onPlate;
	bool oneTime;



	// Use this for initialization
	public void Start () {
		oneTime = false;
		onPlate = false;
		myCollider = GetComponent<BoxCollider2D>();
	}



	void OnTriggerStay2D(Collider2D other)
	{
		if (!oneTime) {
			if (other.CompareTag ("Player") || other.CompareTag ("arm") || other.CompareTag ("torso") || other.CompareTag ("leg")) {


				Flip ();
				onPlate = true;
				Debug.Log ("onplate");
				//Destroy (this.gameObject);

				if (moveDoor) { //toggles the door(s) states
					foreach (GameObject door in affectedDoors) {

						door.GetComponent<DoorController> ().turnOn ();
					}

				}
				if (movePlatform) { //toggles the state of the platform(s)
					foreach (GameObject platform in affectedPlatforms) {

						platform.GetComponent<PlatformController> ().turnOn ();
					}
				}
			}
			oneTime = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player")|| other.CompareTag("arm") || other.CompareTag("torso") || other.CompareTag("leg"))
		{

			Flip ();

			onPlate = false;
			Debug.Log ("Off Plate");
			//Destroy (this.gameObject);

			if (moveDoor) { //toggles the door(s) states
				foreach (GameObject door in affectedDoors) {

					door.GetComponent<DoorController> ().turnOff ();
				}

			} if (movePlatform) { //toggles the state of the platform(s)
				foreach (GameObject platform in affectedPlatforms) {

					platform.GetComponent<PlatformController> ().turnOff ();
				}

			}
		} oneTime = false;
	}


	// Update is called once per frame



	void Flip()
	{
		// Switch the way the player is labelled as facing
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


	//returns true or false if plate is colliding with an object

}