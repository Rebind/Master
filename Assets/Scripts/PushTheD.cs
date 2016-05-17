using UnityEngine;
using System.Collections;

public class PushTheD : MonoBehaviour
{
    private GameObject Player;
    private LimbController arm;
    private Rigidbody2D rgbd;
    private Animator myAnimator;
    private Vector3 addGap = new Vector3(.3f, 0, 0);
    private Vector3 temPosition;
    private Vector3 rockPosition;
    private Vector3 startPosition;
    private float temSpeed;
    private float minimumDistance = 10.0f;
    private float timer = 0.0f;
    private float timer2 = 0.0f;
    private float timeDelta = .5f;
    public Player playerScript;
    private Animator playerAnimator;

    public AudioClip rockSound;
    public AudioSource audioRock;


    void Start()
    {
        Player = GameObject.Find("Player");
        arm = Player.GetComponent<LimbController>();
        rgbd = GetComponent<Rigidbody2D>();
        playerScript = Player.GetComponent<Player>();
        temSpeed = playerScript.moveSpeed;
        startPosition = gameObject.transform.position;
        playerAnimator = Player.GetComponent<Animator>();
        audioRock = this.gameObject.AddComponent<AudioSource>();
        temPosition = gameObject.transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;
        rockPosition = gameObject.transform.position;

        if (timer >= timeDelta)
        {
            temPosition = gameObject.transform.position;

            timer = 0.0f;
        }

        if (Mathf.Abs(rockPosition.x - temPosition.x) > 0.1)
        {
            playerScript.moveSpeed = 3;
            if (!audioRock.isPlaying)
            {
                playSoundEffect();
            }
            playerAnimator.SetLayerWeight(4, 1);
            timer2 = 0;
        }
        else {
            timer2 += Time.deltaTime;
            if (timer2 >= timeDelta)
            {
                stopSoundEffect();
                playerAnimator.SetLayerWeight(4, 0);
            }
        }

        if (temPosition.y < (startPosition.y - 1.0))
        {
            minimumDistance = 200.0f;
        }

        pushController();
    }

    private void pushController()
    {

        if ((Vector3.Distance(transform.position, Player.transform.position) <= minimumDistance) && (arm.hasArm || arm.hasSecondArm))
        {
            //get the position when player press "h"
            temPosition = gameObject.transform.position;
            //Debug.Log ("here:" + temPosition.y);


            rgbd.constraints = RigidbodyConstraints2D.FreezeRotation; //| RigidbodyConstraints2D.FreezePositionY;
                                                                      /*if (playerAnimator.GetFloat("speed") > 0.1)
                                                                      {*/
                                                                      //playerAnimator.SetLayerWeight(4, 1);
                                                                      // }
            gameObject.layer = 11;
            ;
        }
        else if ((Vector3.Distance(transform.position, Player.transform.position) > minimumDistance) && (arm.hasArm || arm.hasSecondArm))
        {
            //Stop sound from playing
            //stopSoundEffect();
            rgbd.constraints = RigidbodyConstraints2D.FreezePositionX;
            //playerAnimator.SetLayerWeight(4, 0);
            gameObject.layer = 8;
            //make a gap 
            //if (gameObject.transform.position.x > temPosition.x) {
            //	gameObject.transform.position += addGap;
            //} else if (gameObject.transform.position.x < temPosition.x) {
            //	gameObject.transform.position -= addGap;
            //}


        }



        if (Vector3.Distance(gameObject.transform.position, Player.transform.position) > 10.0f && (Input.GetKeyDown(KeyCode.X) || Input.GetButtonDown("Xbox_RightButton")))
        {
            stopSoundEffect();
        }
    }

    private void playSoundEffect()
    {
        audioRock.clip = rockSound;
        audioRock.Play();
    }

    private void stopSoundEffect()
    {
        audioRock.Stop();
    }

    //no press key require
    private void pushController2()
    {
        if (arm.hasArm || arm.hasSecondArm)
        {
            rgbd.constraints = RigidbodyConstraints2D.FreezeRotation; //| RigidbodyConstraints2D.FreezePositionY;

            gameObject.layer = 11;
        }
        if (arm.hasArm == false && arm.hasSecondArm == false)
        {
            rgbd.constraints = RigidbodyConstraints2D.FreezePositionX;
            gameObject.layer = 8;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "wall")
        {
            gameObject.layer = 8;
            playerAnimator.SetLayerWeight(4, 0);
            //print (playerScript.velocity.x);
            if (temSpeed > 0)
            {
                playerScript.moveSpeed = -(temSpeed + 8);
            }
            else if (temSpeed < 0)
            {
                playerScript.moveSpeed = -(temSpeed - 8);
            }
            //playerScript.velocity.x =-20;
            //print (playerScript.moveSpeed);
            Destroy(GetComponent<Rigidbody2D>());
        }
    }
}