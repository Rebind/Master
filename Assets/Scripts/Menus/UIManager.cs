using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
	public bool isPaused;
    private GameObject lvlManager;
    AudioSource levelSound;
	public GUISkin customSkin;


    string[] buttons = new string[3] {"Start", "Level Select", "Exit"};
 
	int selected = 0;
	bool inputVertical = false;
	bool userHasHitReturn = false;
	
	public Texture2D resumeButton; 
	public Texture2D quitButton; 
	
	public Texture2D restartButton;

	private GameObject player;
	
	public bool clickedStart = false;
	private bool aPressed = false; 
 
	private AsyncOperation async = null; // When assigned, load is in progress.
	private LevelManager lvlmanager;
	private Loading loading;



 
	int menuSelection (string[] buttonsArray, int selectedItem, string direction) {
 
		if (direction == "up") {
 
			if (selectedItem == 0) {
 
				selectedItem = buttonsArray.Length - 1;
 
			} else {
 
			selectedItem -= 1;
 
			}
	
		}
 
		if (direction == "down") {
 
			if (selectedItem == buttonsArray.Length - 1) {
 
				selectedItem = 0;
 
			} else {
 
				selectedItem += 1;
 
			}
 
		}
		return selectedItem;
	}
 
	
	public void Start(){
		player = GameObject.Find ("Player");
		isPaused = false;
        lvlManager = GameObject.Find("LevelManager");
	}

	void Update(){
		handlePauseToggle ();
		if (isPaused) {
			PauseGame (true);
			handlePauseMenuActions();

		} else {
			PauseGame (false);
		}


	}

	void handlePauseToggle(){
		if (Input.GetKeyDown (KeyCode.P) || (Input.GetButtonDown("Xbox_StartButton"))) {
			isPaused = !isPaused;
			if (!isPaused) {
				player.GetComponent<Player>().enabled = true;
				player.GetComponent<SwitchControl>().enabled = true;

			} else {
				player.GetComponent<Player>().enabled = false;
				player.GetComponent<SwitchControl>().enabled = true;

			}
		} 
	}
		
	void handlePauseMenuActions(){
	
		//knowing what players scroll through
		if(Input.GetAxisRaw("Vertical") == 1){
			if(inputVertical == false){
				selected = menuSelection(buttons, selected, "up");
			}
			inputVertical = true;
 
		}
 
		if(Input.GetAxisRaw("Vertical") == -1){
			if(inputVertical == false){
				selected = menuSelection(buttons, selected, "down");
			}
			inputVertical = true;
 
		}
		
		if(Input.GetAxisRaw("Vertical") == 0){
			inputVertical = false;
		}
		
		//If players pressed the A button on xbox. 
		if(Input.GetButtonDown("Xbox_AButton")){
			aPressed = true;
			Debug.Log ("true");
		}

		else aPressed = false;
 
	
	}
	
	void PauseGame(bool state){
		if (state) {
			Time.timeScale = 0.0f;
            lvlManager.GetComponent<AudioSource>().Pause();
        }
        else {
			Time.timeScale = 1.0f;
            lvlManager.GetComponent<AudioSource>().UnPause();
        }
	}


	void OnGUI(){
		GUI.skin = customSkin;
		GUI.SetNextControlName(buttons[0]);
		Event e = Event.current;
		if(isPaused){
		if(GUI.Button(new Rect(Screen.width/2,Screen.height/2,100,50), resumeButton )){
			isPaused = false;
			if (!isPaused) {
			}
			Debug.Log("Clicked Start");
		}
		//If players select the resume. 
		if(GUI.GetNameOfFocusedControl() == "Start" && (e.keyCode == KeyCode.Return || aPressed)){
			//PlayerPrefs.SetInt("Level", 1);
			//Application.LoadLevel("LoadingScene");	
			isPaused = false;
				if (!isPaused) {
				}
		}
		GUI.SetNextControlName(buttons[1]);
 
 
		//Restart level. 
		if(GUI.Button(new Rect(Screen.width/2,Screen.height/2 + 100,100,50), restartButton)){
			//when selected Options button
			Application.LoadLevel(Application.loadedLevel);
			Debug.Log("Clicked Options");
		}
		//Players select the levels they want
		if(GUI.GetNameOfFocusedControl() == "Level Select" && (e.keyCode == KeyCode.Return || aPressed)){	
			  Application.LoadLevel(Application.loadedLevel);
		}
		GUI.SetNextControlName(buttons[2]);
 
		if(GUI.Button(new Rect(Screen.width/2,Screen.height/2 + 200,100,50), quitButton)){
			//when selected Exit button
			Application.Quit();
			Debug.Log("Exit");
		}
		//If players select exit. 
		if(GUI.GetNameOfFocusedControl() == "Exit" && (e.keyCode == KeyCode.Return || aPressed)){	
			Application.Quit();
		}
		GUI.FocusControl(buttons[selected]);
		}
 
	}

}

