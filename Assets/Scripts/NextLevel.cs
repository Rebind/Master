using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	public Loading loading;
	public GameObject player;
	public LevelManager lvlmanager;
	//private LoadingScene nextScene;
	// Use this for initialization
	void Start () {
		 player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(this.transform.position, player.transform.position) <= 4.5f){
			Debug.Log("in exit");
			nextLevel();
			
		}
	}
	
	private void nextLevel(){
		string currLevel =  Application.loadedLevelName;
		Debug.Log("String: " + currLevel);
		
		switch (currLevel) {
			case "Level-04":
				PlayerPrefs.SetInt("Level",11);
				StartCoroutine("FadingScenes");
				
				
				//Application.LoadLevel(1);
				break;
			case "Level-07":
				PlayerPrefs.SetInt("Level", 13);
				StartCoroutine("FadingScenes");
				
				//Application.LoadLevel(4);
				break;
            case "Level-08":
                PlayerPrefs.SetInt("Level", 14);
                StartCoroutine("FadingScenes");

                //Application.LoadLevel(4);
                break;
            case "Level-09":
                PlayerPrefs.SetInt("Level", 15);
                StartCoroutine("FadingScenes");

                //Application.LoadLevel(4);
                break;
            case "Level-10":
                PlayerPrefs.SetInt("Level", 16);
                StartCoroutine("FadingScenes");

                //Application.LoadLevel(4);
                break;
            case "Level-11":
                PlayerPrefs.SetInt("Level", 0);
                StartCoroutine("FadingScenes");

                //Application.LoadLevel(4);
                break;
            case "BeggLevel":
				PlayerPrefs.SetInt("Level", 6);
				StartCoroutine("FadingScenes");
				
				break;
			case "Level-02":
				PlayerPrefs.SetInt("Level", 9);
				StartCoroutine("FadingScenes");
				
				break;
			case "Level-01":
				PlayerPrefs.SetInt("Level", 8);
				StartCoroutine("FadingScenes");
				
				break;
			case "Level-03":
				PlayerPrefs.SetInt("Level", 4);
				StartCoroutine("FadingScenes");
				
				break;
			case "Level-05":
				PlayerPrefs.SetInt("Level", 12);
				StartCoroutine("FadingScenes");
				
				break;
			case "Level-06":
				PlayerPrefs.SetInt("Level", 1);
				StartCoroutine("FadingScenes");
				
				break;
			default:
				print ("Incorrect intelligence level.");
				break;
		
		}
	}
	
	IEnumerator FadingScenes(){
        //Debug.Log("Loading Level One”);
        float fadeTime = GameObject.FindGameObjectWithTag("fade").GetComponent<FadeScenes>().BeginFade(1);
        yield return new WaitForSeconds(1.0f);
        Application.LoadLevel("LoadingScene");
    }
}
