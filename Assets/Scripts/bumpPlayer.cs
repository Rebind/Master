using UnityEngine;
using System.Collections;

public class bumpPlayer : MonoBehaviour
{

	private Player playerScript;
	private GameObject player;

	public float minDistance;
	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Player");
		playerScript = player.GetComponent<Player> ();
	}

	// Update is called once per frame
	void Update ()
	{

		if (calcDistance (player, this.gameObject) < minDistance) {
			if (player.transform.position.x > this.transform.position.x) {
				bumpRight ();
			} else {
				bumpLeft ();
			}
		} else {
			//playerScript.needMove = false;
		}
	}

	private float calcDistance (GameObject tmp1, GameObject tmp2)
	{
		Transform tr1 = tmp1.transform;
		Transform tr2 = tmp2.transform;
		float distance = Vector3.Distance (tr1.position, tr2.position);
		return distance; 
	}

	private void bumpLeft ()
	{
		//playerScript.leftOfCollider = true;
	}

	private void bumpRight ()
	{
		//playerScript.leftOfCollider = false;
	}



}
