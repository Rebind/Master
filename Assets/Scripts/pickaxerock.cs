using UnityEngine;
using System.Collections;

public class pickaxerock : MonoBehaviour {


	private GameObject Player;
	private MergeAttachDetach play;
    private float minimumDistance = 3.5f;
	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		play = Player.GetComponent<MergeAttachDetach> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(play.hasPickaxe + " in script cs");
		//Debug.Log((Vector3.Distance(Player.transform.position, transform.position) <= minimumDistance));
		if (play.hasPickaxe && (Vector3.Distance(Player.transform.position, transform.position) <= minimumDistance) && Input.GetKeyDown(KeyCode.X))
            { 
			//Debug.Log(play.hasPickaxe + "Testing in here");
			//do something here to the gameobject
			//player has to do some action here
			Destroy(this.gameObject);
		}
	}
}
