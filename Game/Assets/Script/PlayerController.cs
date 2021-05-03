using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed;

    public float jumpForce;

    private Rigidbody2D rb2d;

    public float moveHorizontal;

    public SpriteRenderer player;

    public float jump;

    public bool grounded;

    public LayerMask ground;


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        grounded = Physics2D.Raycast(transform.position, -Vector2.up, 1,ground);

        moveHorizontal = Input.GetAxisRaw("Horizontal");
        player.flipX = moveHorizontal < 0;
        if (grounded)
        {
            jump = Input.GetAxisRaw("Jump");
        }
        else
        {
            jump = 0;
        }

    }

    private void FixedUpdate()
    {
        if (jump > 0)
        {
            rb2d.AddForce(transform.up * jumpForce);
        }
        else
        {

            rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);
        }

    }
}