using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private GameObject player;
	private GameObject Wreck;

    public GameObject deathParticle;
	public GameObject WreckParticle;
   

    public float respawnDelay;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
		Wreck = GameObject.Find("BreakTerrain");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void respawnPlayer()
    {
        StartCoroutine("respawnPlayerCo");

    }
		


	public void destroyWall()
	{
		Wreck.SetActive(false);
		Instantiate(WreckParticle, Wreck.transform.position, Wreck.transform.rotation);
	}

    public IEnumerator respawnPlayerCo()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
		//Instantiate(WreckParticle, Wreck.transform.position, Wreck.transform.rotation);
        player.SetActive(false);
        player.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(respawnDelay);
		//SceneManager.LoadScene ("ninja");
       Application.LoadLevel(Application.loadedLevel);
        yield return new WaitForSeconds(respawnDelay);
        player.SetActive(true);
        player.GetComponent<Renderer>().enabled = true;
        
        //Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
        //player.transform.position = currentCheckpoint.transform.position;
    }
}