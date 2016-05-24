using UnityEngine;
using System.Collections;

public class AcidSound : MonoBehaviour {
	//access the player object to see which limb is in control
	private GameObject tmp;
	private SwitchControl ControlScript;
	//actual game object that's in control
	private GameObject target;
	private AudioSource acidsound;
	//access UI script to get pause state
	private GameObject UIManager;
	private UIManager UIScript;
	float distance;
	// Use this for initialization
	void Start () {
		tmp = GameObject.Find("Player");
		ControlScript = tmp.GetComponent<SwitchControl>();
		target = ControlScript.inControl;
		acidsound = this.GetComponent<AudioSource>();
		UIManager = GameObject.Find("UIManager");
		UIScript = UIManager.GetComponent<UIManager>();
		//set all acid volume to 0 at start of the level
		//acidsound.volume = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		//make sure acid volume is set to 0 when game is paused, 
		//else adjust the volume normally
		if(UIScript.isPaused){ 
			acidsound.volume = 0f;
		}
		else {
			adjustVolume();
		}
	}

	private void adjustVolume(){
		target = ControlScript.inControl;
		//check distance between each acid pit and the player
		distance = calcDistance(this.gameObject, target);
		//if too far away, disable volume, if close enough, scale volume up
		if(distance > 40f){
			acidsound.volume = 0f;
		} else {
			acidsound.volume = 40/distance - 1;
		}
	}

	private float calcDistance(GameObject tmp1, GameObject tmp2)
	{
		Transform tr1 	= tmp1.transform;
		Transform tr2 	= tmp2.transform;
		float distance 	= Vector3.Distance(tr1.position, tr2.position);
		return distance; 
	}

}
