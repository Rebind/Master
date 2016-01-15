using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private float jumpHeight;

    private float timeToJumpApex = .4f;

    [SerializeField]
    private float moveSpeed;
    private bool facingRight;
    private float gravity;

    private float jumpVelocity;

    private Vector3 playerVelocity;

    private Controller2D myController;
    private Animator myAnimator;
    private bool canJump;


    void Start()
    {
        facingRight = true;
        myAnimator = GetComponent<Animator>();
        myController = GetComponent<Controller2D>();
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        jumpVelocity = Mathf.Abs(gravity * timeToJumpApex);
    }

    void Update()
    {
        HandleMovments();
        Flip();
        HandleInputs();
    }

    private void HandleMovments()
    {
        if (myController.collisions.above || myController.collisions.below)
        {
            playerVelocity.y = 0;
        }

        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //get input from the player (left and Right Keys)

        if (Input.GetKeyDown(KeyCode.Space) && myController.collisions.below)  //if spacebar is pressed, jump
        {
            playerVelocity.y = jumpVelocity;
        }
        playerVelocity.x = input.x * moveSpeed;

        playerVelocity.y += gravity * Time.deltaTime;
        myController.Move(playerVelocity * Time.deltaTime);
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


}
