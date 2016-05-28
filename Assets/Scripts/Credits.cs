using UnityEngine;
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


	private void Start(){
		text = GameObject.Find ("Text (1)");
		title = GameObject.Find ("REBINDTitle");
	}

	private void Update()
	{
		//camera.transform.Translate (Vector3.down * Time.deltaTime * speed);
		text.transform.Translate (Vector3.up * Time.deltaTime * speed);
		title.transform.Translate (Vector3.up * Time.deltaTime * speed);
		StartCoroutine ("waitFor");
	}

	IEnumerator waitFor(){
		yield return new WaitForSeconds (35);
		SceneManager.LoadScene (level);
	}
}