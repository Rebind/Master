using UnityEngine;
using System.Collections;

public class Tooltips : MonoBehaviour {

	bool Bbutton = true;
	bool Abutton = true;
	bool detachLegs = true;
	bool detachArms = true;
	bool possessLimb = true;
	bool returnHead = true;
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
	private float minimumDistance = 3.0f;
	//private List<GameObject> whichList = new List<GameObject>();
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		
		BButton = GameObject.FindGameObjectWithTag("interactSign");
		AButton = GameObject.FindGameObjectWithTag("jumpSign");
		legSign = GameObject.FindGameObjectWithTag("signLeg");
		armSign = GameObject.FindGameObjectWithTag("signArm");
		pp1 = GameObject.Find("Pressure Plate (1)");
		pp4 = GameObject.Find("Pressure Plate (4)");
		possessSign = GameObject.FindGameObjectWithTag("signPossess");
		returnSign = GameObject.FindGameObjectWithTag("signReturn");
		arm = GameObject.Find("Arm (1)");
		pp3 = GameObject.Find("Pressure Plate for door one");

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
			Debug.Log("testing in level 1");
			if(Input.GetKeyDown(KeyCode.Z) || Input.GetButtonDown("Xbox_BButton")){
				Bbutton = false;
			}
		}
		else BButton.SetActive(false);
		
		if ((Vector3.Distance(Player.transform.position, quad.transform.position) <= minimumDistance) && Abutton){
			//Debug.Log("testing in here");
			AButton.SetActive(true);
			if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Xbox_AButton") || Input.GetKeyDown(KeyCode.LeftAlt)){
				Abutton = false;
			}
		}
		else AButton.SetActive(false);
	}
	
	//if player is in level 2, show the tutorials for detach
	private void level2Tutorial(){
		
		if ((Vector3.Distance(Player.transform.position, pp1.transform.position) <= minimumDistance) && detachLegs){
			//Debug.Log("testing in here");
			legSign.SetActive(true);
			if(Input.GetKeyDown(KeyCode.S) || Input.GetAxisRaw("XBox_DPadY") == -1){
				detachLegs = false;
			}
			//Bbutton = false;
		}
		else legSign.SetActive(false);
		
		if ((Vector3.Distance(Player.transform.position, pp4.transform.position) <= minimumDistance) && detachArms){
			//Debug.Log("testing in here");
			armSign.SetActive(true);
			if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetAxisRaw("XBox_DPadX") == 1 || Input.GetAxisRaw("XBox_DPadX") == -1){
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
			if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetButtonDown("Xbox_YButton")){
				returnHead = false;
			}
			//Bbutton = false;
		}
		else returnSign.SetActive(false);
		
		if ((Vector3.Distance(Player.transform.position, arm.transform.position) <= 10f) && possessLimb){
			//Debug.Log("testing in here");
			possessSign.SetActive(true);
			if(Input.GetKeyDown(KeyCode.LeftControl) || Input.GetButtonDown("Xbox_XButton")){
				possessLimb = false;
			}
			//Bbutton = false;
		}
		else possessSign.SetActive(false);
	}
	
	private void level4Tutorial(){
	
	}
}
