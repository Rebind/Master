/**
This is used for the empty game object. This is to know where
the projectile is firing from. 
**/

using UnityEngine;
using System.Collections;

public class FiringPoint : MonoBehaviour {

	public GameObject bullets;
	// Use this for initialization
	void Start () {
		//InvokeRepeating ("Fire", 2, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		//replace this with the trigger. Check if player is on top of eye?
		if(Input.GetKeyDown(KeyCode.V)){
			InvokeRepeating("Fire", 2, 2f);
		} else if(Input.GetKeyDown(KeyCode.B)){
			InvokeRepeating("FireHorizontal", 2, 2f);
		}
		
		//If player is longer not on eye, the projectile will stop. Replace it with boolean
		if(Input.GetKeyUp(KeyCode.V)){
			CancelInvoke("Fire");
		}
		else if(Input.GetKeyUp(KeyCode.B)){
			CancelInvoke("FireHorizontal");
		}
	}
	
	void Fire(){
		GameObject player = GameObject.Find("Player");
		if(player != null){
			GameObject bullet = (GameObject) Instantiate(bullets);
			bullet.transform.position = transform.position;
			Vector2 dir = player.transform.position - bullet.transform.position;
			bullet.GetComponent<PickAxeProjectile>().setDirection(dir);
		}
	}
	
	void FireHorizontal(){
		GameObject bullet = (GameObject) Instantiate(bullets);
		bullet.transform.position = transform.position;
		Vector3 pos = bullet.transform.position;
		//float x = ;
		Vector2 dir = new Vector2(pos.x--, pos.y);
		bullet.GetComponent<PickAxeProjectile>().setDirection(dir);
	}
}
