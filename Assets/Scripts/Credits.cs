﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class Credits : MonoBehaviour
{
	public GameObject camera;
	public int speed = 1;
	public string level;
	public GameObject text;
	public GameObject title;
	public GameObject charColors;
	public GameObject sampleTorsoMove;

	private void Start(){
		text = GameObject.Find ("Text (1)");
		title = GameObject.Find ("REBINDTitle");
		charColors = GameObject.Find ("CharColors");
		sampleTorsoMove = GameObject.Find ("SampleTorsoMove");
	}

	private void Update()
	{
		//camera.transform.Translate (Vector3.down * Time.deltaTime * speed);
		text.transform.Translate (Vector3.up * Time.deltaTime * speed);
		title.transform.Translate (Vector3.up * Time.deltaTime * speed);
		charColors.transform.Translate (Vector3.up * Time.deltaTime * speed);
		sampleTorsoMove.transform.Translate (Vector3.up * Time.deltaTime * speed);
		StartCoroutine ("waitFor");
	}

	IEnumerator waitFor(){
		yield return new WaitForSeconds (75);
		SceneManager.LoadScene (level);
	}
}