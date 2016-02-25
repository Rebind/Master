using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	// Use this for initialization

	public bool open;

	public bool requireTwoPlates;
    public Animator mouth;
	private bool startState;
	private BoxCollider2D myCollider;
    private Rigidbody2D myRigidBody;


	public bool plateOne;
	public bool plateTwo;

	void Start () {
		assignState ();
        mouth = GetComponent<Animator>();
		myCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
        myRigidBody = gameObject.GetComponent<Rigidbody2D>() as Rigidbody2D;
        startState = open;

    }



    void assignState(){
		myCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;

		if (open) {
			Debug.Log ("open");
            mouth.SetBool("open", true);		//gameObject.GetComponent<MeshRenderer> ().enabled = false;
			myCollider.size = new Vector2(0,0);
           // myRigidBody.gravityScale = 1;


		} else if (!open) {
			Debug.Log ("closed");
            //gameObject.GetComponent<MeshRenderer> ().enabled = true;
            mouth.SetBool("open", false);
            if (gameObject.name == "mouth_door")
            {
                myCollider.size = new Vector2(1.5f, 0.8f);
            }
            else
            {
                myCollider.size = new Vector2(1, 1);
            }
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
