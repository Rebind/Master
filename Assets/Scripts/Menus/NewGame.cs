using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewGame : MonoBehaviour {

	string[] buttons = new string[3] {"Start", "Level Select", "Exit"};
 
	int selected = 0;
	bool inputVertical = false;
	bool userHasHitReturn = false;
 
	void Start(){
 
		selected = 0;
 
	}
 
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
 
	void Update(){
 
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
 
	}
 
	void OnGUI(){
 
		GUI.SetNextControlName(buttons[0]);
		Event e = Event.current;
        if (e.keyCode == KeyCode.Return) {
			Debug.Log("testing in GUI");
			userHasHitReturn = true;
		}
 
		if(GUI.Button(new Rect(500,200,70,50), buttons[0]) ){
 
			//when selected Start button
			Application.LoadLevel("water");
			Debug.Log("Clicked Start");
 
		}
		
		if(GUI.GetNameOfFocusedControl() == "Start" && e.keyCode == KeyCode.Return){
			Application.LoadLevel("water");
			Debug.Log("Clicked Start");
		}
 
		GUI.SetNextControlName(buttons[1]);
 
		if(GUI.Button(new Rect(500,260,70,50), buttons[1])){
 
			//when selected Options button
			Debug.Log("Clicked Options");
 
		}
 
		GUI.SetNextControlName(buttons[2]);
 
		if(GUI.Button(new Rect(500,320,70,50), buttons[2])){
 
			//when selected Exit button
			Debug.Log("Exit");
 
		}
 
		GUI.FocusControl(buttons[selected]);
 
	}
}
