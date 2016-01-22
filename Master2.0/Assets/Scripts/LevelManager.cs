using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public GameObject currentCheckpoint;
    private Controller2D player;

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
        Debug.Log("player respwan here");
        player.transform.position = currentCheckpoint.transform.position;
    }
}