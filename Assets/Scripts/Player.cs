using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public bool enabled;

	public Vector3 velocity;

	private float minJumpVelocity;
	private float maxJumpVelocity;
    private float maxJumpHeight = 4;
    private float minJumpHeight = 0;
    private float timeToJumpApex = .4f;
	private float oldMoveSpeed;
    public float moveSpeed;
	private float gravity;

	private int state;

    private bool facingRight;
    private bool oldFacing;
	public bool isJumping;
	public bool isClimbing;
	public bool isFalling;
	private bool playSound;
	private Boolean canBump1;
	private Boolean canBump2;

    public LayerMask layer;
    private CameraFollow camScript;
    private Controller2D myTarget;
	private BoxCollider2D myBoxcollider;
	private LimbController limbController;
	private Controller2D myController;
	private Animator myAnimator;
    private Sound sounds;





    void Start()
    {
		moveSpeed = 10f;
		camScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>();
        facingRight = true;
        myBoxcollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
        myAnimator = GetComponent<Animator>();
        myController = GetComponent<Controller2D>();
        print("Gravity: " + gravity + "  Jump Velocity: " + maxJumpVelocity);
        limbController = GetComponent<LimbController>();
        sounds = GetComponent<Sound>();
        playSound = false;
		myTarget = camScript.target;

    }



    void Update()
    {
        if (enabled) {
			Debug.Log ("Jumping: " + isJumping);
			Debug.Log ("Falling: " + isFalling);
            state = myAnimator.GetInteger("state");
            handleMovements();
            handleSpriteFacing();
            handleJumpHeight();
            handleBodyCollisions();
            handleBuffsDebuffs();
            handleSounds();
            handleLayers();
        }

		if (!enabled) {
			velocity.x = 0;
			velocity.y += -10 * Time.deltaTime;
			myController.Move(velocity * Time.deltaTime);
		}
    }


	//Handles player movement taking input from the user
    private void handleMovements()
    {
        if (myController.collisions.above || myController.collisions.below)
        {
            velocity.y = 0;
            myAnimator.SetBool("land", false);

        }


        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //get input from the player (left and Right Keys)

		if ((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Xbox_AButton")) && (myController.collisions.below || (isClimbing && Input.GetAxisRaw("Horizontal") != 0)) && myAnimator.GetInteger("state") != 0)  //if spacebar is pressed, jump
        {
            oldFacing = facingRight;
            velocity.y = maxJumpVelocity;
            sounds.audioJump.PlayOneShot(sounds.jump);
            myAnimator.SetTrigger("jump");
			isJumping = true;


        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Xbox_AButton")) {
            myAnimator.ResetTrigger("jump");
			//isJumping = false;
            if (velocity.y > minJumpVelocity) {
                velocity.y = minJumpVelocity;
            }
        }


        if (velocity.y < 0)
        {
			isJumping = false;
			isFalling = true;
            myAnimator.SetBool("land", true);
		} else {isFalling = false;}


	    velocity.x = input.x * moveSpeed;
		

		if (isClimbing && !isJumping) {
            velocity.y = input.y * moveSpeed;
        }

        else if (!isClimbing) {
            velocity.y += gravity * Time.deltaTime;
        }
        myController.Move(velocity * Time.deltaTime);
        if (myTarget.name == this.gameObject.name)
        {


            myAnimator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        }
        else
        {
            myAnimator.SetFloat("speed", 0);
        }
        //myAnimator.SetFloat("sppeed", Mathf.Abs(Input.GetAxis("Horizontal")));
        /* if (myAnimator.GetFloat("speed") != 0)
         {
             myAnimator.SetBool("isMoving", true);
         }
         else
         {
             myAnimator.SetBool("isMoving", false);
         }*/
    }


	//changes the movement speed of the player charachter based on current limb state
    private void handleBuffsDebuffs()
    {
		if ((isJumping || isFalling) && (oldFacing != facingRight)) {
            moveSpeed = 4f;
        }
        else if (state == 1 || state == 2 || state == 3)
        {
            moveSpeed = 5f;
        }
        else if (state == 4 || state == 6 || state == 8)
        {
            moveSpeed = 7.5f;
        }
        else if (state == 7 || state == 5 || state == 9)
        {
            moveSpeed = 12.5f;
        }
        else
        {
            moveSpeed = 10f;
        }
    }

	//flips the player sprite based on its facing
    private void handleSpriteFacing()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
			if (isJumping || isFalling) {
                oldFacing = !facingRight;
            }
			if (!isJumping && !isFalling) {
                facingRight = !facingRight;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
            }
        }
    }


	//changes the player's jump height based on limb state
    private void handleJumpHeight()
    {
        if (state == 0)
        {
            maxJumpHeight = 1;
        }
        else if (state == 1 || state == 2 || state == 3)
        {
            maxJumpHeight = 2;
        }
        else if (state == 4 || state == 6 || state == 8)
        {
            maxJumpHeight = 4;
        }
        else if (state == 5 || state == 7 || state == 9)
        {
            maxJumpHeight = 7;
        }
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
    }


	//changes the way the player is animated based on state
    private void handleLayers()
    {
        if (isJumping)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            myAnimator.SetLayerWeight(1, 0);
        }
    }


	//changes the players collider based on state (among other things)
    private void handleBodyCollisions()
    {
        //Debug.Log(myTarget.name);

        if (state == 1 || state == 2 || state == 3)
        {
            canBump1 = true;
        }
        if (state == 1)
        {
            canBump2 = true;
        }

        if (myAnimator.GetInteger("state") == 0)
        {
			changeBoxCollider (2.2f, 2.1f, 0f, 1f);
			myController.CalculateRaySpacing ();

        }
        else if(myAnimator.GetInteger("state") == 1)
        {
			changeBoxCollider (2.2f, 3.32f, -0.09f, 1.49f);
			myController.CalculateRaySpacing ();
        }
         else if (myAnimator.GetInteger("state") == 2)
         {
            if (canBump2)
            {
                Vector3 temp = new Vector3(0, 1f, 0);
                gameObject.transform.position += temp;
                canBump2 = false;
            }
            changeBoxCollider (3.45f, 2.27f, 0.48f, 0.07f);
			myController.CalculateRaySpacing ();

        }
         else if (myAnimator.GetInteger("state") == 3)
         {

            changeBoxCollider(3.45f, 2.27f, 0.48f, 0.07f);
            myController.CalculateRaySpacing ();

        }
         else if (myAnimator.GetInteger("state") == 4)
         {
            if (canBump1)
            {
                Vector3 temp = new Vector3(0, 2f, 0);
                gameObject.transform.position += temp;
                canBump1 = false;
            }
            changeBoxCollider (2.22f,4.25f, -0.08f, 0f);
			myController.CalculateRaySpacing ();

        }
         else if (myAnimator.GetInteger("state") == 5)
         {
            changeBoxCollider(2.22f, 4.25f, -0.08f, 0f);
            myController.CalculateRaySpacing ();
        }
         else if (myAnimator.GetInteger("state") == 6)
         {
            if (canBump1)
            {
                Vector3 temp = new Vector3(0, 2f, 0);
                gameObject.transform.position += temp;
                canBump1 = false;
            }
            changeBoxCollider(2.22f, 4.25f, -0.09f, 0f);
            myController.CalculateRaySpacing ();
        }
         else if (myAnimator.GetInteger("state") == 7)
         {

            changeBoxCollider(2.22f, 4.25f, -0.08f, 0f);
            myController.CalculateRaySpacing ();
        }
        else if (myAnimator.GetInteger("state") == 8)
         {
            if (canBump1)
            {
                Vector3 temp = new Vector3(0, 2f, 0);
                gameObject.transform.position += temp;
                canBump1 = false;
            }
            changeBoxCollider(2.22f, 4.25f, -0.08f, 0f);
            myController.CalculateRaySpacing ();
        }
        else if (myAnimator.GetInteger("state") == 9)
         {
            changeBoxCollider(2.22f, 4.25f, -0.08f, 0f);
            myController.CalculateRaySpacing ();
        }
        if (myTarget.name == "Arm" || myTarget.name == "Arm (1)")
        {
            changeBoxCollider(1.53f, 0.49f, -0.02f, -.2f);
            myController.CalculateRaySpacing();
        }
        if (myTarget.name == "Leg" || myTarget.name == "Leg (1)")
        {
            changeBoxCollider(0.61f, 1.21f, 0.16f, -0.65f);
            myController.CalculateRaySpacing();
        }
    }


	//helper function for easy access to box collider size and offset
	private void changeBoxCollider(float xSize, float ySize, float xOffset, float yOffset){

		myBoxcollider.size = new Vector2(xSize,ySize);
		myBoxcollider.offset = new Vector2(xOffset,yOffset);

	}



	//control the collision mask
	private void pushBox(){
		if (Input.GetKeyDown(KeyCode.H)) //&& (arm.hasArm || arm.hasSecondArm))
		{
			myController.collisionMask.value = -3640;
			//Debug.Log(myController.collisionMask.value);
		}
		if (Input.GetKeyUp(KeyCode.H))
		{
			myController.collisionMask.value = -1592;
		}
	}

	/*
	 *
	 * Handle sound effects here. Play the sound when players go left or right. Stop the sound when 
	 * players are not moving or pressing the arrow key
	 * 
	 * 
	 * */
	private void handleSounds()
	{
		if(Input.GetAxisRaw("Horizontal") == 1 && !playSound && myController.collisions.below)
		{
			playSoundDifferentLimbs();
			playSound = true;
		}
		else if (Input.GetAxisRaw("Horizontal") == 0 || !myController.collisions.below)
		{

			playSound = false;
			stopSound();
		}
		else if (Input.GetAxisRaw("Horizontal") == -1 && !playSound)
		{
			playSoundDifferentLimbs();
			playSound = true;
		}	


	}

	/*
	 * Checking for the different limbs in order to play some sounds according to 
	 * the respective body states
	 * 
	 * */
	private void playSoundDifferentLimbs()
	{
		if(!limbController.hasTorso)
		{
			sounds.audioHeadRoll.Play();
		}
		else if(limbController.hasTorso && (!limbController.hasLeg && !limbController.hasSecondLeg)){
			sounds.audioTorso.Play();

		}
		else if(limbController.hasTorso && (limbController.hasLeg || limbController.hasSecondLeg))
		{
			sounds.audioFoot.Play();

		}


	}

	/*
	 * This is to stop the sound from playing when players release the key
	 * 
	 * 
	 * */
	private void stopSound()
	{
		
		foreach (AudioSource audioS in sounds.playerMovementAudioSources) {
			audioS.Stop ();
		}
	}
		

	/*
	}
		if(!checkLimbs.hasTorso)
		{
			sounds.audioHeadRoll.Stop();
		}
		else if(checkLimbs.hasTorso && (!checkLimbs.hasLeg && !checkLimbs.hasSecondLeg)){
			sounds.audioTorso.Stop();
		}
		else if(checkLimbs.hasTorso && (checkLimbs.hasLeg || checkLimbs.hasSecondLeg))
		{
			sounds.audioFoot.Stop();
		}

	}

*/
}
