using UnityEngine;
using System.Collections;

public class fireParticle : MonoBehaviour {

	private GameObject fireBall;
	private Vector3 temPosition;
	private Vector3 newPosition = new Vector3(400.0f, 24.0f, 0);
	private Vector3 outSide = new Vector3(400.0f, 120.0f, 0);
	private float timer;
	private float timerMax;//time for adding high to the player
	private bool outOfCanvas;



	// Use this for initialization
	void Start () {
	   //fireBall = GameObject.Find("fireBall");
	   timer = 0;
	   timerMax = 3;//time for adding high to the player
	   temPosition = gameObject.transform.position;
	   outOfCanvas = true;
	}
	
	// Update is called once per frame
	void Update () {
	   timer += Time.deltaTime;
	   //temPosition.x = gameObject.transform.position.x  + 10;
	   //gameObject.transform.position  = addGap;
	   newPosition = new Vector3(Random.Range(279.0F, 430.0F), Random.Range(7.0F, 70.0F), 0);
	   if(timer >= timerMax){
	   	if(outOfCanvas){
	   	  gameObject.transform.position = outSide;
	   	  outOfCanvas = false;
	   	}else{
	      gameObject.transform.position  = newPosition;
	      outOfCanvas = true;
	    }
	    timer = 0;
	   }

	}
}
