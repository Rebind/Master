using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{

    // Use this for initialization

    public bool open;

<<<<<<< HEAD
    public bool requireMultiplePlates;
    private bool startState;
    private BoxCollider2D myCollider;
=======
	public bool requireMultiplePlates;
	public bool requireTwoPlates;
    public Animator mouth;
	private bool startState;
	private BoxCollider2D myCollider;
>>>>>>> refs/remotes/origin/master
    private Rigidbody2D myRigidBody;
    public Animator mouthDoorAnimator;

<<<<<<< HEAD

    public int neededToOpen;

    [HideInInspector]
    public int platesActivated;
=======
	public int neededToOpen;

	[HideInInspector]
	public int platesActivated;
	public bool plateOne;
	public bool plateTwo;
>>>>>>> refs/remotes/origin/master

    void Start()
    {
        assignState();
        myCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
        mouthDoorAnimator = GetComponent<Animator>();
        startState = open;

    }



<<<<<<< HEAD
    void assignState()
    {
        myCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;

        if (open)
        {
            Debug.Log("open");
            
            //gameObject.GetComponent<MeshRenderer>().enabled = false;
            myCollider.size = new Vector2(0, 0);
            mouthDoorAnimator.SetBool("open", true);


        }
        else if (!open)
        {
            Debug.Log("closed");
            //gameObject.GetComponent<MeshRenderer>().enabled = true;

            //if (gameObject.name == "mouth_door")
           // {
               
            myCollider.size = new Vector2(1.5f, 0.8f);
            mouthDoorAnimator.SetBool("open", false);
            // }

            //else {
            //myCollider.size = new Vector2(1, 1);
            //}
        }
    }

=======
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
>>>>>>> refs/remotes/origin/master

    public void toggle()
    {
        open = !open;
        assignState();

    }


    public void turnOn()
    {
        if (!requireMultiplePlates)
        {
            open = !startState;
            assignState();
        }
        else if (requireMultiplePlates)
        {
            Debug.Log(platesActivated);
            if (platesActivated == neededToOpen)
            {
                open = !startState;
                assignState();
            }
        }
    }

    public void turnOff()
    {
        open = startState;
        assignState();
    }
}