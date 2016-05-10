using UnityEngine;
using System.Collections;

public class raycastBump : MonoBehaviour {

	public LayerMask collisionMask;



	void FixedUpdate() {
		RaycastHit2D checkLeft = Physics2D.Raycast(new Vector2(this.transform.position.x,this.transform.position.y+1f), Vector2.right * -1, 10f, collisionMask);
		RaycastHit2D checkRight = Physics2D.Raycast(new Vector2(this.transform.position.x,this.transform.position.y+1f), Vector2.right * 1, 10f, collisionMask);


		Debug.Log ("hitLeft " + checkLeft.distance);
		Debug.Log ("hitRight " + checkRight.distance);

		if (checkLeft.distance > checkRight.distance) {
			Debug.Log ("Closer to Left");

		} else if (checkLeft.distance < checkRight.distance) {
			Debug.Log ("Closer to Right");
		} else if ((checkLeft.distance == 0) && (checkRight.distance == 0)) {
			Debug.Log("Not Near any Walls");
		}

	}
}
