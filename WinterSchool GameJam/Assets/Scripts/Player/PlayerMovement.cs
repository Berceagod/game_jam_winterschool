using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce = 12f;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        //Grabs references for rigidbody and animator from game object.
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        //Flip player when facing left/right.
        if (Input.GetKey(KeyCode.A))
            transform.localScale = new Vector3(-5,5,1);
        else if (Input.GetKey(KeyCode.D))
            transform.localScale = new Vector3(5, 5, 1);

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();

        //sets animation parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
        body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}