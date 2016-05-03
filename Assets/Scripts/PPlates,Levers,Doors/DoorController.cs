using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	// Use this for initialization

	public bool open;


    public Animator mouth;
	private bool startState;
	private BoxCollider2D myCollider;
    private Rigidbody2D myRigidBody;

	public int neededToOpen;

	private bool opening;
	private bool closing;


	public AudioClip doorOpen;
	public AudioClip doorClose;
	private AudioSource audioDoor;


	[HideInInspector]
	public int platesActivated;





	void Start () {
		audioDoor = this.gameObject.AddComponent<AudioSource>();
		assignState ();
		if (gameObject.name == "mouth_door") {
			mouth = GetComponent<Animator> ();
		}
		myCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
        startState = open;

    }



    void assignState(){
		myCollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;

		if (open) {
			if (audioDoor.isPlaying) {
				audioDoor.Stop ();
			}
			audioDoor.clip = doorOpen;
			audioDoor.Play();


			Debug.Log ("open");
			if (gameObject.name == "mouth_door") {
				mouth.SetBool ("open", true);		//gameObject.GetComponent<MeshRenderer> ().enabled = false;
			} else {
				opening = true;
			}
			
			myCollider.size = new Vector2(0,0);
           // myRigidBody.gravityScale = 1;
		} else if (!open) {
			if (audioDoor.isPlaying) {
				audioDoor.Stop ();
			}
			audioDoor.clip = doorClose;
			audioDoor.Play();

			Debug.Log ("closed");
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

	public void toggle(){
		Debug.Log (open);
		open = !open;
		assignState ();
		Debug.Log (open);

	}


    public void turnOn()
    {
		if (neededToOpen<=0) {
			open = !startState;
			assignState ();
		} else if (neededToOpen != null) {
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
			if (this.gameObject.GetComponent<MeshRenderer> ().material.color.a <= 0.2f) {
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

}
