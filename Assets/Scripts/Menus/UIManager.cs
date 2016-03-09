using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public GameObject pausePanel;
	public bool isPaused;

	public void Start(){
		isPaused = false;
		//tempSpeed = playerScripts.moveSpeed;
	}

	void Update(){
		if (isPaused) {
			PauseGame (true);
		} else {
			PauseGame (false);
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			switchPause ();
		}
	}
		
	void PauseGame(bool state){
		if (state) {
			Time.timeScale = 0.0f;
		} else {
			Time.timeScale = 1.0f;
		}
		pausePanel.SetActive (state);
	}

	public void switchPause(){
		if (isPaused) {
			isPaused =false;
		}else{
			isPaused =true;
		}
	}

}

