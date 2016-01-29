using UnityEngine;
using System.Collections;

public class pickaxerock : MonoBehaviour {


	private GameObject Player;
	private MergeAttachDetach play;
	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		play = Player.GetComponent<MergeAttachDetach> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (play.hasPickaxe) {
			//do something here to the gameobject
			//player has to do some action here
			Destroy(this.gameObject);
		}
	}
}
