using UnityEngine;
using System.Collections;

public class bat_movement : MonoBehaviour {
		
	private bool movingRight;

		// put the points from unity interface
		public Vector2[] wayPointList;
		private Vector3 theScale;

		public int currentWayPoint = 0; 

		public float speed = 4f;

		// Use this for initialization
		void Start () {
		}

	void Update () {

		

	

		if ((Vector2)transform.position == wayPointList[currentWayPoint]) {
			if (currentWayPoint == wayPointList.Length-1) {
				if ((Vector2)this.transform.position == wayPointList [currentWayPoint]) {
					currentWayPoint = 0;
				}
			} else {
				currentWayPoint++;

			}


		}

		if (this.transform.position.x > wayPointList [currentWayPoint].x) {
			movingRight = true;
		} else {
			movingRight = false;
		}

		assignSpriteFacing();

		this.transform.position = Vector2.MoveTowards (this.transform.position, wayPointList [currentWayPoint], speed * Time.deltaTime);


		}

	void OnDrawGizmos() {
		if (wayPointList != null) {
			Gizmos.color = Color.red;
			float size = .3f;

			for (int i =0; i < wayPointList.Length; i ++) {
				Vector3 globalWaypointPos = wayPointList [i];
				Gizmos.DrawLine(globalWaypointPos - Vector3.up * size, globalWaypointPos + Vector3.up * size);
				Gizmos.DrawLine(globalWaypointPos - Vector3.left * size, globalWaypointPos + Vector3.left * size);
			}
		}
	}


	void assignSpriteFacing(){
		if (movingRight) {
			GetComponent<SpriteRenderer> ().flipX = false;
		} else {
			GetComponent<SpriteRenderer> ().flipX = true;

		}
	}




	}