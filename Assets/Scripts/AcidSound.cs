using UnityEngine;
using System.Collections;

public class AcidSound : MonoBehaviour {
	public GameObject tmp;
	public SwitchControl ControlScript;
	public GameObject target;
	//public GameObject acidpit;
	public AudioSource acidsound;
	float distance;
	// Use this for initialization
	void Start () {
		tmp = GameObject.Find("Player");
		ControlScript = tmp.GetComponent<SwitchControl>();
		target = ControlScript.inControl;
		acidsound = this.GetComponent<AudioSource>();
		//acidpit = this;
	}
	
	// Update is called once per frame
	void Update () {
		target = ControlScript.inControl;
		distance = calcDistance(this.gameObject, target);
		if(distance > 40){
			acidsound.volume = 0;
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
