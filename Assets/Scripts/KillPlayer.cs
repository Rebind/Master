using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{

    public LevelManager mylevelmanager;
    private Sound sounds;
    private GameObject player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sounds = player.GetComponent<Sound>();
        mylevelmanager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("player respwan here");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //sounds.audiodead.Play();
        if (other.tag == "Player")
        {

            sounds.audiodead.Play();
            Debug.Log("player respawn here");
            mylevelmanager.GetComponent<AudioSource>().Stop();
            mylevelmanager.respawnPlayer();
        } 
        if (other.tag == "leg" || other.tag == "arm") {
            mylevelmanager.respawnLimb(other.name);
        }

    }

}