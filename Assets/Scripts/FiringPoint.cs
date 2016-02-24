/**
This is used for the empty game object. This is to know where
the projectile is firing from. 
**/

using UnityEngine;
using System.Collections;

public class FiringPoint : MonoBehaviour {

	public GameObject bullets;
	
	public bool triggerFirePlayer = false;
	public bool triggerFireHorizontal = false;
	// Use this for initialization
	void Start () {
		//InvokeRepeating ("Fire", 2, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		/*replace this with the trigger. Check if player is on top of eye?
		if(triggerFirePlayer){
			InvokeRepeating("Fire", 2, 2.5f);
		} if(triggerFireHorizontal){
			InvokeRepeating("FireHorizontal", 2, 2f);
		}
		
		//If player is longer not on eye, the projectile will stop. Replace it with boolean
		if(triggerFirePlayer = false){
			CancelInvoke("Fire");
		}
		if(triggerFireHorizontal = false){
			CancelInvoke("FireHorizontal");
		}*/
	}
	
	//If player is on the eye, then shoot projectile depending on what the eye triggers
	public void toggleFireAtPlayer(){
		Debug.Log("true in Toggle fire at player");
		triggerFirePlayer = true;
		InvokeRepeating("Fire", 2, 2.5f);
	}
	
	public void toggleFireHorizontal(){
		triggerFireHorizontal = true;
	
	}
	
	
	//Turn off the projectiles. 
	public void turnOffFireAtPlayer(){
		triggerFirePlayer = false;
		CancelInvoke("Fire");
	}
	
	public void turnOffFireHorizontal(){
		triggerFireHorizontal = false;
	
	}
	
	private void Fire(){
		GameObject player = GameObject.Find("Player");
		if(player != null){
			GameObject bullet = (GameObject) Instantiate(bullets);
			bullet.transform.position = transform.position;
			Vector2 dir = player.transform.position - bullet.transform.position;
			bullet.GetComponent<PickAxeProjectile>().setDirection(dir);
		}
	}
	
	private void FireHorizontal(){
		GameObject bullet = (GameObject) Instantiate(bullets);
		bullet.transform.position = transform.position;
		Vector3 pos = bullet.transform.position;
		Vector2 dir = new Vector2(pos.x--, pos.y);
		bullet.GetComponent<PickAxeProjectile>().setDirection(dir);
	}
}