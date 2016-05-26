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

	private void Start(){
		text = GameObject.Find ("Text (1)");
	}

	private void Update()
	{
		//camera.transform.Translate (Vector3.down * Time.deltaTime * speed);
		text.transform.Translate (Vector3.up * Time.deltaTime * speed);
		StartCoroutine ("waitFor");
	}

	IEnumerator waitFor(){
		yield return new WaitForSeconds (30);
		SceneManager.LoadScene (level);
	}
}