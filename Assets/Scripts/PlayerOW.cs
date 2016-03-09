using UnityEngine;
using System.Collections;

public class PlayerOW : MonoBehaviour {
	private OverWorld OWScript;
	private GameObject OW;
	private GameObject player;
	private GameObject target;
	public Vector3 targetPos;

	private void setNewTarget() {
		string tmp = null;
		if (Input.GetKeyUp(KeyCode.W)) {
            tmp = OWScript.Levels.getNewPos("up");
            target = GameObject.Find(tmp);
        }
        if (Input.GetKeyUp(KeyCode.A)) {
            tmp = OWScript.Levels.getNewPos("left");
            target = GameObject.Find(tmp);
        }
        if (Input.GetKeyUp(KeyCode.S)) {
            tmp = OWScript.Levels.getNewPos("down");
            target = GameObject.Find(tmp);
        }
        if (Input.GetKeyUp(KeyCode.D)) {
            tmp = OWScript.Levels.getNewPos("right");
            target = GameObject.Find(tmp);
        }
        if (Input.GetKeyUp(KeyCode.Return)) {
            tmp = OWScript.Levels.getCurr();
            target = GameObject.Find(tmp);
            if (target.transform.position == player.transform.position){
            	//load level using tmp as level name;
            }
        }
	}

	// Use this for initialization
	void Start () {
		OW = GameObject.Find("OverWorld");
		OWScript = OW.GetComponent<OverWorld>();
		player = GameObject.Find("PlayerOW");
		target = GameObject.Find("Blah");
		player.transform.position = target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		setNewTarget();
		targetPos = new Vector3(target.transform.position.x, target.transform.position.y, 
			target.transform.position.z);
		transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.1f);
	}
}
