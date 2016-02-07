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
		if (Input.GetKeyUp(KeyCode.E) || Input.GetAxisRaw("Xbox_LeftTrigger"))
		{
			//Debug.Log("E is pressed");
			newTarget = FindClosestLimb();
			if (newTarget != null) {
				newTargetName = newTarget.name;
				toggleScript (newTarget, true);
				toggleScript (inControl, false);
				inControl = newTarget;
			}
		}
		//Return to head
		if (Input.GetKeyUp(KeyCode.Q) || Input.GetAxisRaw("Xbox_RightTrigger"))
		{
			//Debug.Log("Q is pressed");
			GameObject PlayerObj = GameObject.Find("Player");
			toggleScript (PlayerObj, true);
			toggleScript (inControl, false);
			inControl = PlayerObj;
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
