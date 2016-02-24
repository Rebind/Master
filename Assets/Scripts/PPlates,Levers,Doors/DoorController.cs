using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	// Use this for initialization

	public bool open;

	public bool requireMultiplePlates;
	private bool startState;
	private BoxCollider2D myCollider;
    private Rigidbody2D myRigidBody;


	public int neededToOpen;

	[HideInInspector]
	public int platesActivated;

	void Start () {
		assignState ();		
		myCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
        startState = open;

	}
	


	void assignState(){
		myCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;

		if (open) {
			Debug.Log ("open");

			gameObject.GetComponent<MeshRenderer> ().enabled = false;
			myCollider.size = new Vector2(0,0);


		} else if (!open) {
			Debug.Log ("closed");
			gameObject.GetComponent<MeshRenderer> ().enabled = true;

			myCollider.size = new Vector2(1,1);
		}
	}


	public void toggle(){
		open = !open;
		assignState ();

	}


    public void turnOn()
    {
		if (!requireMultiplePlates) {
			open = !startState;
			assignState ();
		} else if (requireMultiplePlates) {
			Debug.Log (platesActivated);
			if (platesActivated == neededToOpen) {
				open = !startState;
				assignState ();
			}
		}
    }

    public void turnOff()
    {
        open = startState;
        assignState();
    }
}
