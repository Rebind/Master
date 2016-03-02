/*
 * This is to test if player is near an environment that can be
 * destructible with the pickaxe
 * 
 * 
 * 
 * */

using UnityEngine;
using System.Collections;

public class pickaxeHit : MonoBehaviour {
	public LevelManager mylevelmanager;

	GameObject Player;
	LimbController pickaxe;
<<<<<<< HEAD
=======
    public Animator playerAnimator;
    bool canDestroy;
>>>>>>> refs/remotes/origin/master
	float minimumDistance = 10.5f;
	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		pickaxe = Player.GetComponent<LimbController> ();
<<<<<<< HEAD
	
=======
        playerAnimator = Player.GetComponent<Animator>();
>>>>>>> refs/remotes/origin/master
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
		
		if (pickaxe.hasPickaxe && Vector3.Distance (transform.position, Player.transform.position) <= minimumDistance && Input.GetKeyDown(KeyCode.X)) {
			Debug.Log ("testing in here now");
			mylevelmanager.destroyWall();
		}
	
	}
=======
            if (pickaxe.hasPickaxe && Input.GetKeyDown(KeyCode.X) && Vector3.Distance (transform.position, Player.transform.position) <= minimumDistance) {
                Debug.Log("testing in here now");
                mylevelmanager.destroyWall();
            } 
    }
>>>>>>> refs/remotes/origin/master
}
