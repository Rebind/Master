using UnityEngine;
using System.Collections;

public class Nose : MonoBehaviour {

	BoxCollider2D myCollider;
	private GameObject Player;
	private MergeAttachDetach arm;
	private Rigidbody2D rgbd;
	private Animator myAnimator;
	//private Vector3 addHigh = new Vector3(0,20.0f,0);
	private float addHigh = 20f;
	private float timer = 0;
	private float timerMax = 8;
	private Vector3 temPosition;
	public Player playerScript;

	// Use this for initialization
	public void Start () {
		myCollider = GetComponent<BoxCollider2D>();
		Player = GameObject.Find("Player");
		arm = Player.GetComponent<MergeAttachDetach>();
		rgbd = GetComponent<Rigidbody2D>();
		playerScript = Player.GetComponent<Player>();

	}

	void Update(){
		timer += Time.deltaTime;
		if (timer >= timerMax) {
			Debug.Log ("timerMax reached !");
			addHigh = 20f;
			// reset timer
		} 
		if (timer > timerMax+5) {
			addHigh = 0;
			timer = 0;
		}
		Debug.Log (addHigh);
	}
	void OnTriggerStay2D(Collider2D other){
		//Debug.Log ("nose1");
		//playerScript.velocity.y += 1;
		//playerScript.velocity += addHigh;
		//other.GetComponent<Player> ().velocity += addHigh;

		if (other.CompareTag ("Player") || other.CompareTag ("arm") || other.CompareTag ("torso") || other.CompareTag ("leg")) {
			Debug.Log (playerScript.velocity.y);
			playerScript.notOnNose = false;
			//other.GetComponent<Player> ().velocity += addHigh;
			playerScript.velocity.y += addHigh * Time.deltaTime;
			Debug.Log ("nose");
			//Destroy (this.gameObject);
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		playerScript.notOnNose = true;
		Debug.Log ("lala");
	}
		
}