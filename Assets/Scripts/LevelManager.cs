using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private Controller2D player;

    public GameObject deathParticle;
   

    public float respawnDelay;
    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Controller2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void respawnPlayer()
    {
        StartCoroutine("respawnPlayerCo");

    }

    public IEnumerator respawnPlayerCo()
    {
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(respawnDelay);
		SceneManager.LoadScene ("defaultTestScene");
      //  Application.LoadLevel(Application.loadedLevel);
        yield return new WaitForSeconds(respawnDelay);
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        
        //Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
        //player.transform.position = currentCheckpoint.transform.position;
    }
}