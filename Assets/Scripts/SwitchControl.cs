using UnityEngine;
using System.Collections;

public class SwitchControl : MonoBehaviour {
	public GameObject inControl;
	public CameraFollow CameraScript;
	public GameObject 	cameraObject;
	public Player PlayerScript;
	//public GameObject[] Limbs;
	public GameObject[] Legs;
	public GameObject[] Arms;
	public ArrayList Limbs = new ArrayList();

	public GameObject Closest;
	public GameObject newTarget;
	public string newTargetName;
	public float setDistance = 10f;
	private bool axisLeft = false;
	private bool axisRight = false;
	// Use this for initialization
	void Start () {
		cameraObject = GameObject.Find("Main Camera");
		CameraScript = cameraObject.GetComponent<CameraFollow>();
		Closest = null;
		inControl = GameObject.Find("Player");
		Legs = GameObject.FindGameObjectsWithTag("leg");
		Arms = GameObject.FindGameObjectsWithTag("arm");

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
				newTarget = FindClosestLimb();
				if (newTarget != null) {
					newTargetName = newTarget.name;
					toggleScript (newTarget, true);
					toggleScript (inControl, false);
					inControl = newTarget;
				}
				axisLeft = true;
			}
		}
		//Return to head
		else if (Input.GetKeyUp(KeyCode.Q) || Input.GetAxisRaw("Xbox_RightTrigger") != 0)
		{
			//Debug.Log("Q is pressed");
			if(axisRight == false){
				GameObject PlayerObj = GameObject.Find("Player");
				toggleScript (PlayerObj, true);
				toggleScript (inControl, false);
				inControl = PlayerObj;
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