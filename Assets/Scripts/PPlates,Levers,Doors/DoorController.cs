using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	// Use this for initialization

	public bool open;

	public bool requireTwoPlates;
	private bool startState;
	private BoxCollider2D myCollider;

	public bool plateOne;
	public bool plateTwo;

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
		if (!requireTwoPlates) {
			open = !startState;
			assignState ();
		} else if (requireTwoPlates) {
			if (plateOne && plateTwo) {
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
