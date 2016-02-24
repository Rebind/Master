using UnityEngine;
using System.Collections;

public class LeverController : MonoBehaviour {

	BoxCollider2D myCollider;


	public bool moveDoor;
	public bool movePlatform;

	public float maximumActivationDistance;

	public GameObject[] affectedDoors;
	public GameObject[] affectedPlatforms;
	public GameObject head;
	public SwitchControl inControl;
	public GameObject control;
	public LimbController Arm;

	[SerializeField]
	public GameObject camera;

	private CameraFollow myCamera;



	bool onPlate;
	bool oneTime;



	// Use this for initialization
	public void Start () {
		maximumActivationDistance = 1.5f;
		camera = GameObject.Find("Main Camera");
		myCamera = camera.GetComponent<CameraFollow> ();
		
		head = GameObject.Find("Player");
		inControl = head.GetComponent<SwitchControl>();
		Arm = head.GetComponent<LimbController>();
		
		
		
		oneTime = false;
		onPlate = false;
	}

	void Update(){
		control = inControl.inControl;
		if(Input.GetKeyDown(KeyCode.Z) && (control.tag == "arm" || Arm.hasArm || Arm.hasSecondArm) && nearLever()){
			Debug.Log("LEVER WORKS!");
			toggleLever ();
		}
	}


	bool nearLever(){
		if (Vector3.Distance (this.transform.position, myCamera.targetTransform.position) < maximumActivationDistance) {
			return true;
		} else {
			return false;
		}

	}


	public void toggleLever(){

				if (moveDoor) { //toggles the door(s) states
					foreach (GameObject door in affectedDoors) {

						door.GetComponent<DoorController> ().toggle ();
					}

				}
				if (movePlatform) { //toggles the state of the platform(s)
					foreach (GameObject platform in affectedPlatforms) {

						platform.GetComponent<PlatformController> ().toggle ();
					}
				}
	}


}