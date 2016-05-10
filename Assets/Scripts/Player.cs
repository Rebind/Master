using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
	public bool enabled;

	public Vector3 velocity;

	private float minJumpVelocity;
	public float maxJumpVelocity;
	public float maxJumpHeight = 4;
	private float minJumpHeight = 0;
	private float timeToJumpApex = .4f;

	private float oldMoveSpeed;
	public float moveSpeed;
	private float gravity;

	private int state;

	public bool needMove;
	public bool facingRight;
	private bool oldFacing;
	public bool isJumping;
	private bool midJump;
	public bool isClimbing;
	public bool notOnNose;
	private bool playSound;
	private Boolean canBump1;
	private Boolean canBump2;

	public bool leftOfCollider;
	private float raycastOffset;



	public LayerMask layer;
	private CameraFollow camScript;
	private Controller2D myTarget;
	private BoxCollider2D myBoxcollider;
	private LimbController limbController;
	private Controller2D myController;
	private Animator myAnimator;
	private Sound sounds;
	public Animator playerAnim;

	void Start()
	{
		//switchControl = GameObject.FindGameObjectWithTag("Player").GetComponent<SwitchControl>();
		moveSpeed = 10f;
		playerAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>() as Animator;
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
		notOnNose = true;
		needMove = true;
	}



	void Update()
	{
        myTarget = camScript.target;
        if (enabled) {
			state = myAnimator.GetInteger("state");
			handleMovements();
			handleSpriteFacing ();
			handleJumpHeight();
			handlePlayerMovementSpeed ();
			handleBodyCollisions();
			handleLayers();
			handleEdgeDetection ();
		}

		if (!enabled && notOnNose) {
			velocity.x = 0;
            velocity.y = -10;// * Time.deltaTime;
			myController.Move (velocity * Time.deltaTime);

		}

        if (myTarget.tag == "Player")
        {
            
            playerAnim.SetLayerWeight(2, 0);
        }
        else
        {
           
            playerAnim.SetLayerWeight(2, 1);
        }

    }





	//Handles player movement taking input from the user
	private void handleMovements()
	{
		if ((myController.collisions.above || myController.collisions.below) && notOnNose)
		{
			velocity.y = 0;
			myAnimator.SetBool("land", false);

		}


		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //get input from the player (left and Right Keys)

		if ((Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.Space) ||Input.GetButtonDown("Xbox_AButton")) 
		&& (myController.collisions.below || (isClimbing)) && (myAnimator.GetInteger("state") != 0 || this.tag.Equals("leg")) && notOnNose)  //if spacebar is pressed, jump
		{
			oldFacing = facingRight;
			velocity.y = maxJumpVelocity;
		    sounds.audioJump.Play();
			myAnimator.SetTrigger("jump");
			isJumping = true;
		}

		if (isJumping && !myController.collisions.below) {
			midJump = true;
		} 

	

		if (midJump && myController.collisions.below) {
			isJumping = false;
			midJump = false;
			myAnimator.ResetTrigger("jump");

		}


		if ((Input.GetKeyUp(KeyCode.LeftAlt) || Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Xbox_AButton")) && notOnNose) {
			if (velocity.y > minJumpVelocity) {
				velocity.y = minJumpVelocity;
			}
		}


		if (velocity.y < 0)
		{
			myAnimator.SetBool("land", true);
		} 


		if (!isClimbing || isClimbing && myController.collisions.below) {
			velocity.x = input.x * moveSpeed;
		}


		if (isClimbing && notOnNose && !myController.collisions.below) {
			velocity.y = input.y * moveSpeed;
			velocity.x = 0;
            myAnimator.SetLayerWeight(3, 1);
            if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
            {	
				if (!sounds.audioClimb.isPlaying) {
					sounds.audioClimb.Play ();
				}
            }
        }

		else if (!isClimbing && notOnNose) {
            myAnimator.SetLayerWeight(3, 0);
            velocity.y += gravity * Time.deltaTime;
		}
		myController.Move(velocity * Time.deltaTime);
		if (myTarget.name == this.gameObject.name)
		{

            myAnimator.SetFloat("speedVert", Mathf.Abs(Input.GetAxis("Vertical")));
			if (myController.collisions.left || myController.collisions.right) {
				myAnimator.SetFloat ("speed", 0);
			} else {
				myAnimator.SetFloat ("speed", Mathf.Abs (velocity.x));
			}
		}
		else
		{
			myAnimator.SetFloat("speed", 0);
		}
	}


	//changes the movement speed of the player charachter based on current limb state
	private void handlePlayerMovementSpeed()
	{
		
		if ((isJumping) && (oldFacing != facingRight)) {
			moveSpeed = 4f;
		}
		else if (state == 1 || state == 2 || state == 3)
		{
			moveSpeed = 7f;
		}
		else if (state == 4 || state == 6 || state == 8)
		{
			moveSpeed = 14f;
		}
		else if (state == 7 || state == 5 || state == 9)
		{
			moveSpeed = 20f;
		}
		else
		{
			moveSpeed = 12f;
		}
			
	}

	//flips the player sprite based on its facing
	private void handleSpriteFacing()
	{
		Debug.Log (state);
		float horizontal = Input.GetAxis("Horizontal");
		if (!isClimbing) {
			if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {

				if (isJumping) {
					if ((state != 2) && (state != 3)) {
						oldFacing = !facingRight;
					} else {
						facingRight = !facingRight;
						Vector3 theScale = transform.localScale;
						theScale.x *= -1;
						transform.localScale = theScale;
					}
				}
				if (!isJumping) {
					facingRight = !facingRight;
					Vector3 theScale = transform.localScale;
					theScale.x *= -1;
					transform.localScale = theScale;
				}
			}
		} else {
			if (horizontal < 0 && !facingRight || horizontal > 0 && facingRight) {

				 
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
		if (this.tag.Equals("leg")){

			maxJumpHeight = 4;
		}
		else if (state == 0)
		{
			maxJumpHeight = 1;
		}
		else if (state == 1 || state == 2 || state == 3)
		{
			maxJumpHeight = 3;
		}
		else if (state == 4 || state == 6 || state == 8)
		{
			maxJumpHeight = 6;
		}
		else if (state == 5 || state == 7 || state == 9)
		{
			maxJumpHeight = 10;
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


	/*
	* 0 -  just the head
	* 1 - head and torso
	* 2 - head torso and one arm
	* 3 - head torso and both arms
	* 4 - head torso, both arms and one leg
	* 5 - full body
	* 6 - head, torso and one leg
	* 7 - head, torso and both legs
	* 8 - head, torso, leg and one arm
	* 9 - head, torso, arm and two legs
	*/

	private void handleBodyCollisions()
	{
		//Debug.Log(myTarget.name);

		if (this.tag.Equals("leg") || this.tag.Equals("arm")) {
			return;
		}

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
			Vector3 temp1 = new Vector3(0f, 0, 0);

			changeBoxCollider (2.2f, 2.1f, 0f, 1f);
			myController.CalculateRaySpacing ();
			needMove = false;
			raycastOffset = 1f;

		}
		else if(myAnimator.GetInteger("state") == 1)
		{
			changeBoxCollider (2.2f, 3.32f, -0.09f, 1.49f);
			myController.CalculateRaySpacing ();
			needMove = true;
			raycastOffset = 2f;
		}
		else if (myAnimator.GetInteger("state") == 2)
		{
			Vector3 temp1 = new Vector3(1.25f, 0, 0);

			if (canBump2)
			{
				Vector3 temp = new Vector3(0, 1f, 0);
				gameObject.transform.position += temp;
				canBump2 = false;
			}
			changeBoxCollider (3.45f, 2.27f, 0.48f, 0.07f);
			myController.CalculateRaySpacing ();
			raycastOffset = 1f;

		}
		else if (myAnimator.GetInteger("state") == 3)
		{
			Vector3 temp1 = new Vector3(1.25f, 0, 0);

            if (isClimbing)
            {
                changeBoxCollider(3.45f, 2.27f, 0.48f, 0.07f);
                myController.CalculateRaySpacing();
            }
            else
            {
                changeBoxCollider(3.45f, 2.27f, 0.48f, 0.07f);
                myController.CalculateRaySpacing();
            }
			raycastOffset = 1f;

		}
		else if (myAnimator.GetInteger("state") == 4)
		{
			if (canBump1)
			{
				Vector3 temp = new Vector3(0, 2f, 0);
				gameObject.transform.position += temp;
				canBump1 = true;
			}
            if (isClimbing)
            {
                changeBoxCollider(1.43f, 3.64f, 0.17f, 0f);
                myController.CalculateRaySpacing();
            }
            else
            {
                changeBoxCollider(2.22f, 4.25f, -0.08f, 0f);
                myController.CalculateRaySpacing();
            }
			raycastOffset = 2f;

		}
		else if (myAnimator.GetInteger("state") == 5)
		{
            if (isClimbing)
            {
                changeBoxCollider(1.43f, 3.64f, 0.17f, 0f);
                myController.CalculateRaySpacing();
            }
            else
            {
                changeBoxCollider(2.22f, 4.25f, -0.08f, 0f);
                myController.CalculateRaySpacing();
            }
			raycastOffset = 2f;
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
			raycastOffset = 2f;
		}
		else if (myAnimator.GetInteger("state") == 7)
		{

			changeBoxCollider(2.22f, 4.25f, -0.08f, 0f);
			myController.CalculateRaySpacing ();
			raycastOffset = 2f;
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
			raycastOffset = 2f;
		}
		else if (myAnimator.GetInteger("state") == 9)
		{
			changeBoxCollider(2.22f, 4.25f, -0.08f, 0f);
			myController.CalculateRaySpacing ();
			raycastOffset = 2f;
		}

	}


	//helper function for easy access to box collider size and offset
	private void changeBoxCollider(float xSize, float ySize, float xOffset, float yOffset){

		myBoxcollider.size = new Vector2(xSize,ySize);
		myBoxcollider.offset = new Vector2(xOffset,yOffset);

	}




	private void handleEdgeDetection() {
		RaycastHit2D checkLeft = Physics2D.Raycast(new Vector2(this.transform.position.x,this.transform.position.y+raycastOffset), Vector2.right * -1, 4f, myController.collisionMask);
		RaycastHit2D checkRight = Physics2D.Raycast(new Vector2(this.transform.position.x,this.transform.position.y+raycastOffset), Vector2.right * 1, 4f, myController.collisionMask);



		if ((checkRight.distance != 0) && (checkLeft.distance > checkRight.distance)) { //within range of both, closer to right

			needMove = true;
			leftOfCollider = true;

		} else if ((checkLeft.distance != 0) && (checkRight.distance > checkLeft.distance)) { //within range of both, closer to left
			needMove = true;
			leftOfCollider = false;
		} else if ((checkLeft.distance == 0) && (checkRight.distance == 0)) { //within range of no walls. 
			needMove = false;
		} else if (checkLeft.distance == 0) { //within range of right only, closer to right
			needMove = true;
			leftOfCollider = true;
		} else if (checkRight.distance == 0) { //within range of left only, closer to left
			needMove = true;
			leftOfCollider = false;
		}

	}

	public void bumpPlayer(Vector3 bump){ //bumps the player depending on position relative to nearby colliders, takes a Vector2 representing the distance in x bumped.
		if (needMove) {
			if (leftOfCollider)
				gameObject.transform.position -= bump;
			else
				gameObject.transform.position += bump;
		}
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
