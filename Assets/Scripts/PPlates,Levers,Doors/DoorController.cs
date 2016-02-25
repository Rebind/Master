using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	// Use this for initialization

	public bool open;

<<<<<<< HEAD
	public bool requireMultiplePlates;
=======
	public bool requireTwoPlates;
    public Animator mouth;
>>>>>>> refs/remotes/origin/Josue_MyMaster
	private bool startState;
	private BoxCollider2D myCollider;
    private Rigidbody2D myRigidBody;


<<<<<<< HEAD
	public int neededToOpen;

	[HideInInspector]
	public int platesActivated;
=======
	public bool plateOne;
	public bool plateTwo;
>>>>>>> refs/remotes/origin/Josue_MyMaster

	void Start () {
		assignState ();
        mouth = GetComponent<Animator>();
		myCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
        startState = open;

    }



    void assignState(){
		myCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;

		if (open) {
			Debug.Log ("open");
<<<<<<< HEAD

			gameObject.GetComponent<MeshRenderer> ().enabled = false;
			myCollider.size = new Vector2(0,0);
=======
            mouth.SetBool("open", true);		//gameObject.GetComponent<MeshRenderer> ().enabled = false;
			myCollider.size = new Vector2(0,0);
           // myRigidBody.gravityScale = 1;
>>>>>>> refs/remotes/origin/Josue_MyMaster


		} else if (!open) {
			Debug.Log ("closed");
<<<<<<< HEAD
			gameObject.GetComponent<MeshRenderer> ().enabled = true;

			myCollider.size = new Vector2(1,1);
		}
	}
=======
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
>>>>>>> refs/remotes/origin/Josue_MyMaster


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
