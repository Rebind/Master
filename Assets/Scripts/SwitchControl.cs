using UnityEngine;
using System.Collections;

public class SwitchControl : MonoBehaviour {
	//variable to keep track of which object is in controll
	public GameObject inControl;
	//local instances of other script objects
	public CameraFollow CameraScript;
	public GameObject 	cameraObject;
	public Player PlayerScript;
	//data structures to hold game objects
	public GameObject[] Legs;
	public GameObject[] Arms;
	public ArrayList Limbs = new ArrayList();
	//set the distance at which the control can be switched between limbs
	public float setDistance = 10f;
	private bool axisLeft = false;
	private bool axisRight = false;
	// Use this for initialization
	void Start () {
		//find the camera object and obtain its script
		cameraObject = GameObject.Find("Main Camera");
		CameraScript = cameraObject.GetComponent<CameraFollow>();
		//initialize the object in control to be the head at first
		inControl = GameObject.Find("Player");
		//collect all the objects with tags "leg" and "arm" in 
		//data structures
		Legs = GameObject.FindGameObjectsWithTag("leg");
		Arms = GameObject.FindGameObjectsWithTag("arm");
		//merge the two arrays into one
		for (int i = 0; i < Legs.Length; i++) 
		{
			Limbs.Add(Legs[i]);
		}

		for (int i = 0; i < Arms.Length; i++) 
		{
			Limbs.Add(Arms[i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Switch to nearest limb
		if (Input.GetKeyUp(KeyCode.E) || Input.GetAxisRaw("Xbox_LeftTrigger") != 0)
		{
			//Debug.Log("E is pressed");
			if(axisLeft == false){
				GameObject newTarget = FindClosestLimb();
				if (newTarget != null) {
					toggleScript (newTarget, true);
					toggleScript (inControl, false);
					inControl = newTarget;
					CameraScript.ChangeTarget(newTarget.name);
				}
				axisLeft = true;
			}
		}
		//Return to head
		else if (Input.GetKeyUp(KeyCode.Q) || Input.GetAxisRaw("Xbox_RightTrigger") != 0)
		{
			//Debug.Log("Q is pressed");
			if(axisRight == false){
				GameObject newTarget = GameObject.Find("Player");
				toggleScript (newTarget, true);
				toggleScript (inControl, false);
				inControl = newTarget;
				CameraScript.ChangeTarget(newTarget.name);
				axisRight = true;
			}
		}
		//This is to make sure the axis on the xbox is pressed only once. Without this, then, the changed player
		//won't move. 
		if(Input.GetAxisRaw("Xbox_LeftTrigger") == 0){
			axisLeft = false;
		}
		if(Input.GetAxisRaw("Xbox_RightTrigger") == 0){
			axisRight = false;
		}
	}

	private void toggleScript (GameObject target, bool OnOff) 
	{
		PlayerScript = target.GetComponent<Player>();
		PlayerScript.enabled = OnOff;
	}

	private GameObject FindClosestLimb () {
		float distance = Mathf.Infinity;
		GameObject Closest = null;

		foreach (GameObject tmp in Limbs)
		{
			float newDistance = calcDistance(tmp, inControl);
			if ((newDistance < distance) && (tmp != inControl) 
				&& (newDistance < setDistance))
			{
				distance = newDistance;
				Closest = tmp;
			}
		}
		return Closest;
	}

	private float calcDistance(GameObject tmp1, GameObject tmp2)
	{
		Transform tr1 	= tmp1.transform;
		Transform tr2 	= tmp2.transform;
		float distance 	= Vector3.Distance(tr1.position, tr2.position);
		return distance; 
	}
}