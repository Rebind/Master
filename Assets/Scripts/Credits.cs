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
	public GameObject charColors;
	public GameObject sampleTorsoMove;
	public GameObject rebindlogo;
	public GameObject SampleArmDrag;
	public GameObject chardesign;
	public GameObject fullbodyavatar;
	public GameObject SampleTorsoJump;
	public GameObject rebindteam;

	private void Start(){
		text = GameObject.Find ("Text (1)");
		title = GameObject.Find ("REBINDTitle");
		charColors = GameObject.Find ("CharColors");
		sampleTorsoMove = GameObject.Find ("SampleTorsoMove");
		rebindlogo = GameObject.Find ("REBINDLOGO");
		chardesign = GameObject.Find ("chardesign");
		fullbodyavatar = GameObject.Find ("fullbodyavatar");
		SampleTorsoJump  = GameObject.Find ("SampleTorsoJump");
		rebindteam = GameObject.Find ("rebindteam");
	}

	private void Update()
	{
		//camera.transform.Translate (Vector3.down * Time.deltaTime * speed);
		text.transform.Translate (Vector3.up * Time.deltaTime * speed);
		title.transform.Translate (Vector3.up * Time.deltaTime * speed);
		charColors.transform.Translate (Vector3.up * Time.deltaTime * speed);
		sampleTorsoMove.transform.Translate (Vector3.up * Time.deltaTime * speed);
		rebindlogo.transform.Translate (Vector3.up * Time.deltaTime * speed);
		chardesign.transform.Translate (Vector3.up * Time.deltaTime * speed);
		fullbodyavatar.transform.Translate (Vector3.up * Time.deltaTime * speed);
		SampleTorsoJump.transform.Translate (Vector3.up * Time.deltaTime * speed);
		rebindteam.transform.Translate (Vector3.up * Time.deltaTime * speed);
		StartCoroutine ("waitFor");
	}

	IEnumerator waitFor(){
		yield return new WaitForSeconds (75);
		SceneManager.LoadScene (level);
	}
}