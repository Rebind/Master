using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour
{

    public LevelManager mylevelmanager;
	private GameObject Player;
	private MergeAttachDetach getBoot;

    // Use this for initialization
    void Start()
    {
        mylevelmanager = FindObjectOfType<LevelManager>();
		Player = GameObject.Find("Player");
		getBoot = Player.GetComponent<MergeAttachDetach>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("player respwan here");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
		Debug.Log(getBoot.hasBoot);
        if (other.name == "Player" && !getBoot.hasBoot)
        {
            Debug.Log("player respwan here");
            mylevelmanager.respawnPlayer();
        }

    }

}