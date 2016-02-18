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
		//replace this with the trigger. CHeck if player is on top of eye?
		if(Input.GetKeyDown(KeyCode.V)){
			InvokeRepeating("Fire", 2, 2f);
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
}
