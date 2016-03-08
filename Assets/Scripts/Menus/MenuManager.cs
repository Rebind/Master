using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	public Menu CurrentMenu;
	private Player playerScripts;
	private GameObject Player;
	public GameObject Canvas;
	public bool isPaused;
	//private float tempSpeed;
	private float tempJumpHeight;


	public void Start(){
		Player = GameObject.Find("Player");
		isPaused = false;
		playerScripts = Player.GetComponent<Player>();
		//tempSpeed = playerScripts.moveSpeed;
	}

	void Update(){
		if (isPaused) {
			//PauseGame (true);
			ShowMenu(CurrentMenu);
		} else {
			CurrentMenu.IsOpen = false;
			//PauseGame (false);
		}
		if (Input.GetButtonDown ("Cancel")) {
			switchPause ();
			//tempSpeed = playerScripts.moveSpeed;
			Debug.Log (playerScripts.isJumping);
		}
		if (isPaused == true) {
			playerScripts.moveSpeed = 0.0f;
			//playerScripts.isJumping = false;
		} 
	}

	public void ShowMenu(Menu menu){
		if (CurrentMenu != null)
			CurrentMenu.IsOpen = false;
		CurrentMenu = menu;
		CurrentMenu.IsOpen = true;
	}

	void PauseGame(bool state){
		if (state) {
			Time.timeScale = 0.0f;
		} else {
			Time.timeScale = 1.0f;
		}
	}

	public void switchPause(){
		if (isPaused) {
				isPaused =false;
			}else{
				isPaused =true;
			}
		}
		
}

