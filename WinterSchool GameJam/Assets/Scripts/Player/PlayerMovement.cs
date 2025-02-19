using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D body;
    private Animator anim;
    private float lastGroundedY;
    //private bool meleeAttack = false;
    private bool grounded = false;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
        anim.SetBool("falling", false);
        lastGroundedY = transform.position.y;


    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        //// Flip player when facing left/right
        //if (Input.GetKey(KeyCode.A))
        //    transform.localScale = new Vector3(-1, 1, 1);
        //else if (Input.GetKey(KeyCode.D))
        //    transform.localScale = new Vector3(1, 1, 1);

        // Only the feet collider determines if the player is grounded
        //grounded = groundDetector.IsGrounded();


        // Handle falling animation logic
        if (grounded)
        {
            anim.SetBool("falling", false);
           
        }
        //else if (!grounded && transform.position.y < lastGroundedY)
        //{
        //    anim.SetBool("falling", true);
        //    lastGroundedY = transform.position.y;
        //    grounded = true;
        //}

        // Set animation parameters
        anim.SetBool("run", horizontalInput != 0);
    }


    //public bool canAttack()
    //{
    //    if (meleeAttack == true)
    //    {
    //        return true;
    //    }
    //    return false;
    //}
}