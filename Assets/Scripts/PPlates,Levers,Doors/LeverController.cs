using UnityEngine;
using System.Collections;

public class LeverController : MonoBehaviour {

	BoxCollider2D myCollider;

    private bool on;

	public float maximumActivationDistance;

	public GameObject[] affectedDoors;
	public GameObject[] affectedPlatforms;


	private Camera camera;

	private CameraFollow myCamera;


	public AudioClip ppOn;
	public AudioClip ppOff;
	public AudioSource audioPP;


	// Use this for initialization
	public void Start () {
		camera = Camera.main;
		maximumActivationDistance = 1.5f;
		myCamera = camera.GetComponent<CameraFollow> ();
        on = true;
		audioPP = this.gameObject.AddComponent<AudioSource>();
	}

	void Update(){
		if((Input.GetKeyDown(KeyCode.X) || Input.GetButtonDown("Xbox_BButton")) && nearLever()){
			toggleLever ();
            this.gameObject.GetComponent<SpriteRenderer>().flipY = on;
            on = !on;
		}

	}


	bool nearLever(){
		if (myCamera.target.tag == "Player" || myCamera.target.tag == "arm") {
			if (Vector3.Distance (this.transform.position, myCamera.targetTransform.position) < maximumActivationDistance) {
				return true;
			} else {
				return false;
			}
		} else
			return false;

	}


	public void toggleLever(){

		if (audioPP.isPlaying) {
			audioPP.Stop ();
		} else {
			if(on){
			audioPP.clip = ppOn;
			} else {
			audioPP.clip = ppOff;
			}
			audioPP.Play ();
		}

		if (affectedDoors != null) { //toggles the door(s) states
					foreach (GameObject door in affectedDoors) {

						door.GetComponent<DoorController> ().toggle ();
					}

				}
		if (affectedPlatforms != null) { //toggles the state of the platform(s)
					foreach (GameObject platform in affectedPlatforms) {

						platform.GetComponent<PlatformController> ().toggle ();
					}
				}
	}


}