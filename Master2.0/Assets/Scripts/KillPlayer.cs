using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{

    public LevelManager mylevelmanager;

    // Use this for initialization
    void Start()
    {
        mylevelmanager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2d(Collider2D other)
    {
        if (other.name == "Player")
        {
            Debug.Log("player respwan here");
            mylevelmanager.respawnPlayer();
        }
        Debug.Log("player respwan here");
    }

}