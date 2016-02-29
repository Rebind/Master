﻿/*
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
    public Animator playerAnimator;
    bool canDestroy;
	float minimumDistance = 10.5f;
	// Use this for initialization
	void Start () {
		Player = GameObject.Find ("Player");
		pickaxe = Player.GetComponent<LimbController> ();
        playerAnimator = Player.GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X)){
            playerAnimator.SetTrigger("attack");
            if (pickaxe.hasPickaxe && Vector3.Distance (transform.position, Player.transform.position) <= minimumDistance) {
            
            
                Debug.Log("testing in here now");
                mylevelmanager.destroyWall();
                //playerAnimator.SetLayerWeight(5, 1);
               
            }
          
		}
       /* else
        {
            playerAnimator.SetLayerWeight(5, 0);
        }*/

    }
}
