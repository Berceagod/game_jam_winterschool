using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 12f;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private float lastGroundedY;
    bool meleeAttack = false;


    private void Awake()
    {
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("falling", false);
        lastGroundedY = transform.position.y;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);


        //Flip player when facing left/right.
        if (Input.GetKey(KeyCode.A))
            transform.localScale = new Vector3(-1,1,1);
        else if (Input.GetKey(KeyCode.D))
            transform.localScale = new Vector3(1, 1, 1);

        if (Input.GetKey(KeyCode.W) && grounded)
        {
            Jump();
            lastGroundedY = transform.position.y;
        }
      
         if(grounded)
        {
            anim.SetBool("falling", false);
            anim.SetBool("grounded", grounded);
        }
        else if (!grounded && transform.position.y < lastGroundedY)
        {
            anim.SetBool("falling", true);
            lastGroundedY = transform.position.y;
            grounded = true;

        }
        //sets animation parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {

    
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
            grounded = false;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
            lastGroundedY = transform.position.y; // Update last grounded Y position
        }
        if (collision.gameObject.CompareTag("Weapon"))
        {
            meleeAttack = true;
            Physics2D.IgnoreLayerCollision(9, 8, true);
        }   
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }

    public bool canAttack()
    {
        if (meleeAttack == true)
        {
            return true;
        }
        return false;
    }
}