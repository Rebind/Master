using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	// Use this for initialization

	public bool open;

<<<<<<< HEAD
	public bool requireTwoPlates;
=======
	public bool requireMultiplePlates;
	public bool requireTwoPlates;
    public Animator mouth;
>>>>>>> refs/remotes/origin/master
	private bool startState;
	private BoxCollider2D myCollider;
    private Rigidbody2D myRigidBody;

<<<<<<< HEAD
	public bool plateOne;
	public bool plateTwo;
=======
	public int neededToOpen;


	private bool opening;
	private bool closing;


	[HideInInspector]
	public int platesActivated;

>>>>>>> refs/remotes/origin/master

	void Start () {
		assignState ();
		if (gameObject.name == "mouth_door") {
			mouth = GetComponent<Animator> ();
		}
		myCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
<<<<<<< HEAD
        myRigidBody = gameObject.GetComponent<Rigidbody2D>() as Rigidbody2D;
        startState = open;
=======
        startState = open;

    }
>>>>>>> refs/remotes/origin/master



    void assignState(){
		myCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;

		if (open) {

<<<<<<< HEAD
			//gameObject.GetComponent<MeshRenderer> ().enabled = false;
			//myCollider.size = new Vector2(0,0);
            myRigidBody.gravityScale = 1;

=======
>>>>>>> refs/remotes/origin/master


			Debug.Log ("open");
			if (gameObject.name == "mouth_door") {
				mouth.SetBool ("open", true);		//gameObject.GetComponent<MeshRenderer> ().enabled = false;
			} else {
				opening = true;
			}
			
			myCollider.size = new Vector2(0,0);
           // myRigidBody.gravityScale = 1;
		} else if (!open) {
			Debug.Log ("closed");
<<<<<<< HEAD
			//gameObject.GetComponent<MeshRenderer> ().enabled = true;

			//myCollider.size = new Vector2(1,1);
		}
	}
=======
            //gameObject.GetComponent<MeshRenderer> ().enabled = true;
			if (gameObject.name == "mouth_door") {
				mouth.SetBool("open", false);

				myCollider.size = new Vector2 (1.5f, 0.8f);
			} else {
				closing = true;
                myCollider.size = new Vector2(1, 1);
            }
        }
    }
>>>>>>> refs/remotes/origin/master


	public void toggle(){
		open = !open;
		assignState ();

<<<<<<< HEAD
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
=======
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


	public void Update(){


		Color color = this.gameObject.GetComponent<MeshRenderer> ().material.color;


		if (opening && open) {

			this.gameObject.GetComponent<MeshRenderer> ().material.color = new UnityEngine.Color (color.r, color.g, color.b, color.a - .025f);   
			if (this.gameObject.GetComponent<MeshRenderer> ().material.color.a <= 0f) {
				opening = false;
			}
		}
		if (closing && !open) {

			this.gameObject.GetComponent<MeshRenderer> ().material.color = new UnityEngine.Color (color.r, color.g, color.b, color.a + .025f);   
			if (this.gameObject.GetComponent<MeshRenderer> ().material.color.a >= 1f) {
				closing = false;
			}
		}

	}

>>>>>>> refs/remotes/origin/master
}
