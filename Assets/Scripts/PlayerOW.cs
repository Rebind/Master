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
        if (Input.GetKeyUp(KeyCode.Return) || Input.GetButtonDown("Xbox_AButton")) {
            tmp = OWScript.Levels.getCurr();
            target = GameObject.Find(tmp);
			
            if (target.transform.position == player.transform.position){
				//Loading screen
				
				switch (tmp) {
				case "Level_1":
					PlayerPrefs.SetInt("Level", 1);
					Application.LoadLevel("LoadingScene");
					break;
				case "Level_2":
					PlayerPrefs.SetInt("Level", 2);
					Application.LoadLevel("LoadingScene");
					break;
				case "Level_3":
					PlayerPrefs.SetInt("Level", 3);
					Application.LoadLevel("LoadingScene");
					break;
				case "Level_4":
					PlayerPrefs.SetInt("Level", 4);
					Application.LoadLevel("LoadingScene");
					break;
				case "Level_5":
					PlayerPrefs.SetInt("Level", 5);
					Application.LoadLevel("LoadingScene");
					break;
				case "Level_6":
					PlayerPrefs.SetInt("Level", 6);
					Application.LoadLevel("LoadingScene");
					break;
				case "Level_7":
					PlayerPrefs.SetInt("Level", 7);
					Application.LoadLevel("LoadingScene");
					break;
				case "Level_8":
					PlayerPrefs.SetInt("Level", 8);
					Application.LoadLevel("LoadingScene");
					break;
				case "Level_9":
					PlayerPrefs.SetInt("Level", 9);
					Application.LoadLevel("LoadingScene");
					break;
				case "Level_10":
					PlayerPrefs.SetInt("Level", 10);
					Application.LoadLevel("LoadingScene");
					break;
				case "Level_11":
					PlayerPrefs.SetInt("Level", 11);
					Application.LoadLevel("LoadingScene");
					break;
			
				default:
					print ("Incorrect intelligence level.");
					break;
				}
            }
		}
	}

	
	
	// Use this for initialization
	void Start () {
		OW = GameObject.Find("OverWorld");
		OWScript = OW.GetComponent<OverWorld>();
		player = GameObject.Find("PlayerOW");
		target = GameObject.Find("Level_1");
		player.transform.position = target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		setNewTarget();
		targetPos = new Vector3(target.transform.position.x, target.transform.position.y, 
			target.transform.position.z);
		transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.3f);
	}
}
