using UnityEngine;
using System.Collections;

public class Tooltips : MonoBehaviour {

	bool Bbutton;
	bool Abutton;
	bool detachLegs;
	bool detachArms;
	bool possessLimb;
	bool returnHead;
	GameObject Player;
	GameObject BButton;
	GameObject AButton;
	GameObject legSign;
	GameObject armSign;
	GameObject torso;
	GameObject pp1;
	GameObject pp4;
	GameObject quad;
	GameObject pp3;
	GameObject arm;
	GameObject possessSign;
	GameObject returnSign;
	private float minimumDistance = 2.5f;
	//private List<GameObject> whichList = new List<GameObject>();
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		BButton = GameObject.Find("XBox-Interact");
		AButton = GameObject.Find("XBox-Jump");
		legSign = GameObject.FindGameObjectWithTag("signLeg");
		armSign = GameObject.FindGameObjectWithTag("signArm");
		pp1 = GameObject.Find("Pressure Plate (1)");
		pp4 = GameObject.Find("Pressure Plate (4)");
		possessSign = GameObject.FindGameObjectWithTag("signPossess");
		returnSign = GameObject.FindGameObjectWithTag("signReturn");
		arm = GameObject.Find("Arm (1)");
		pp3 = GameObject.Find("Pressure Plate for door one");
		Bbutton = true;
		Abutton = true;
		detachLegs = true;
		detachArms = true;
		possessLimb = true;
		returnHead = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		string currLevel =  Application.loadedLevelName;
		
		switch (currLevel) {
			case "Level-01":
				level1Tutorial();
				break;
			case "Level-02":
				level2Tutorial();
				break;
			case "Level-03":
				level3Tutorial();
				break;
			default:
				print ("Incorrect intelligence level.");
				break;
		}	
	}
	
	
	//if player is in level 1, show the tutorials for attach and climbing rope
	private void level1Tutorial(){
		
		torso = GameObject.FindGameObjectWithTag("torso");
		quad = GameObject.Find("Quad");
		if ((Vector3.Distance(Player.transform.position, torso.transform.position) <= minimumDistance) && Bbutton){
			BButton.SetActive(true);
			if(Input.GetKeyDown(KeyCode.Z)){
				Bbutton = false;
			}
			//Bbutton = false;
		}
		else BButton.SetActive(false);
		
		if ((Vector3.Distance(Player.transform.position, quad.transform.position) <= minimumDistance) && Abutton){
			//Debug.Log("testing in here");
			AButton.SetActive(true);
			if(Input.GetKeyDown(KeyCode.Space)){
				Abutton = false;
			}
			//Bbutton = false;
		}
		else AButton.SetActive(false);
	}
	
	//if player is in level 2, show the tutorials for detach
	private void level2Tutorial(){
		
		if ((Vector3.Distance(Player.transform.position, pp1.transform.position) <= minimumDistance) && detachLegs){
			//Debug.Log("testing in here");
			legSign.SetActive(true);
			if(Input.GetKeyDown(KeyCode.S)){
				detachLegs = false;
			}
			//Bbutton = false;
		}
		else legSign.SetActive(false);
		
		if ((Vector3.Distance(Player.transform.position, pp4.transform.position) <= minimumDistance) && detachArms){
			//Debug.Log("testing in here");
			armSign.SetActive(true);
			if(Input.GetKeyDown(KeyCode.A)){
				detachArms = false;
			}
			//Bbutton = false;
		}
		else armSign.SetActive(false);
	}
	
	//If player is in this level 3, show the tutorials for possessing limb and returning to head. 
	private void level3Tutorial(){
		
		//possessSign.SetActive(false);
		if ((Vector3.Distance(arm.transform.position, pp3.transform.position) <= 2.0f) && returnHead){
			//Debug.Log("testing in here");
			returnSign.SetActive(true);
			if(Input.GetKeyDown(KeyCode.LeftShift)){
				returnHead = false;
			}
			//Bbutton = false;
		}
		else returnSign.SetActive(false);
		
		if ((Vector3.Distance(Player.transform.position, arm.transform.position) <= 10f) && possessLimb){
			//Debug.Log("testing in here");
			possessSign.SetActive(true);
			if(Input.GetKeyDown(KeyCode.LeftControl)){
				possessLimb = false;
			}
			//Bbutton = false;
		}
		else possessSign.SetActive(false);
	}
	
	private void level4Tutorial(){
	
	}
}
