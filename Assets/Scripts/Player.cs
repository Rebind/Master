using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
	public bool enabled;

	private float maxJumpHeight =4;
	private float minJumpHeight =0;

    private float timeToJumpApex = .4f;

    private float moveSpeed;
    private bool facingRight;
    private float gravity;


    private float minJumpVelocity;
	private float maxJumpVelocity;

    private Vector3 velocity;
    private BoxCollider2D myBoxcollider;
    private Controller2D myController;
    private Animator myAnimator;
    private bool canJump;
    private int state;
	private Sound sounds;
	private bool playSound;
	public LayerMask layer;

    void Start()
    {
        moveSpeed = 10f;
        facingRight = true;
        myBoxcollider = gameObject.GetComponent<BoxCollider2D>() as BoxCollider2D;
        myAnimator = GetComponent<Animator>();
        myController = GetComponent<Controller2D>();


		gravity = -(2 * maxJumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJumpHeight);
		print ("Gravity: " + gravity + "  Jump Velocity: " + maxJumpVelocity);
		sounds = GetComponent<Sound>();
    }

    void Update()
    {
		if(enabled){
        state = myAnimator.GetInteger("state");
        HandleMovments();
        Flip();
        HandleInputs();
        handleBodyCollisions();
        handleBuffsDebuffs();
		//pushBox ();
		}
    }

    private void HandleMovments()
    {
        if (myController.collisions.above || myController.collisions.below)
        {
            velocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //get input from the player (left and Right Keys)
		Debug.Log("Test input " + Input.GetAxisRaw("Horizontal"));
		if(Input.GetAxisRaw("Horizontal") == 1){
			sounds.audioHeadRoll.Play();
		}
		else if (Input.GetAxisRaw("Horizontal") == 0){
			sounds.audioHeadRoll.Stop();
		}
		/*else if (Input.GetAxisRaw("Horizontal") == -1){
			sounds.audioHeadRoll.Play();
		}*/
		
		/*if(Input.GetKeyDown(KeyCode.H)){
			sounds.audioHeadRoll.Play();
		}
		else if(Input.GetKeyUp(KeyCode.H)){
			sounds.audioHeadRoll.Stop();
		}*/
			
        if (Input.GetKeyDown(KeyCode.Space) && myController.collisions.below && myAnimator.GetInteger("state") != 0)  //if spacebar is pressed, jump
        {
            velocity.y = maxJumpVelocity;
        }
		if(Input.GetKeyUp(KeyCode.Space)){
			if(velocity.y > minJumpVelocity){
				velocity.y = minJumpVelocity;
			}
		}
        velocity.x = input.x * moveSpeed;

        velocity.y += gravity * Time.deltaTime;
        myController.Move(velocity * Time.deltaTime);
        myAnimator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        if (myAnimator.GetFloat("speed") != 0)
        {
            myAnimator.SetBool("isMoving", true);
        }
        else
        {
            myAnimator.SetBool("isMoving", false);
        }
    }

    private void handleBuffsDebuffs()
    {
    
        if (state == 1 || state == 2 || state == 3)
        {
            moveSpeed = 5f;
          //  jumpHeight = 3f;
        }
        else if (state == 4 || state == 6 || state == 8)
        {
            moveSpeed = 7.5f;
           // jumpHeight = 6f;
        }
        else if (state == 7 || state == 5 || state == 9)
        {
            moveSpeed = 12.5f;
           // jumpHeight = 9f;
        }
        else
        {
            moveSpeed = 10f;
        }
    }

    private void Flip()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0 && !facingRight || horizontal<0 && facingRight)
         {
                facingRight = !facingRight;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
          }
        }

    private void HandleInputs()
    {

    }

    private void handleBodyCollisions()
    {
        if (myAnimator.GetInteger("state") == 0)
        {
			changeBoxCollider (1.2f, 1.2f, 0f, 0f);
			myController.CalculateRaySpacing ();

        }
        else if(myAnimator.GetInteger("state") == 1)
        {
			changeBoxCollider (2.1f, 4.78f, 0f, 1.45f);
			myController.CalculateRaySpacing ();
        }
         else if (myAnimator.GetInteger("state") == 2)
         {

			changeBoxCollider (2.62f, 4.78f, -0.11f, 1.45f);
			myController.CalculateRaySpacing ();

        }
         else if (myAnimator.GetInteger("state") == 3)
         {

			changeBoxCollider (3.01f,4.78f,.04f, 1.45f);
			myController.CalculateRaySpacing ();

        }
         else if (myAnimator.GetInteger("state") == 4)
         {
			changeBoxCollider (2.73f,8.38f, .02f, 3.53f);
			myController.CalculateRaySpacing ();

        }
         else if (myAnimator.GetInteger("state") == 5)
         {
			changeBoxCollider (2.73f, 8.38f, .02f, 3.53f);
			myController.CalculateRaySpacing ();
        }
         else if (myAnimator.GetInteger("state") == 6)
         {
			changeBoxCollider (2.1f, 8.38f, 0f, 3.53f);
			myController.CalculateRaySpacing ();
        }
         else if (myAnimator.GetInteger("state") == 7)
         {

			changeBoxCollider (2.1f, 8.38f, 0f, 3.53f);
			myController.CalculateRaySpacing ();
        }
        else if (myAnimator.GetInteger("state") == 8)
         {

			changeBoxCollider (2.31f, 8.38f, -.19f, 3.53f);
			myController.CalculateRaySpacing ();
        }
        else if (myAnimator.GetInteger("state") == 9)
         {
			changeBoxCollider (2.38f, 8.38f, -.19f, 3.53f);
			myController.CalculateRaySpacing ();
        }
    }



	private void changeBoxCollider(float xSize, float ySize, float xOffset, float yOffset){

		myBoxcollider.size = new Vector2(xSize,ySize);
		myBoxcollider.offset = new Vector2(xOffset,yOffset);

	}

    private void helperBoxCollider(float someFloat, string type, string var)
    {
        if (type.Equals("size"))
        {
            Vector3 size = myBoxcollider.size;
            if (var.Equals("x"))
            {
                size.x = someFloat;
            }
            else if (var.Equals("y"))
            {
                size.y = someFloat;
            }
            myBoxcollider.size = size;
        }
        else if (type.Equals("offset"))
        {
            Vector3 offset = myBoxcollider.offset;
            if (var.Equals("x"))
            {
                offset.x = someFloat;
            }
            else if (var.Equals("y"))
            {
                offset.y = someFloat;
            }
            myBoxcollider.offset = offset;
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
	
	private void playSoundSteps(){
		if(playSound) return;
		sounds.audioHeadRoll.Play();
		playSound = false;
	}

}
