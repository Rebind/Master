using UnityEngine;
using System.Collections;

public class disablePP : MonoBehaviour {

	public GameObject lever;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (lever.GetComponent<LeverController> ().on == true) {
			gameObject.SetActive (false);
		}
	}
}
