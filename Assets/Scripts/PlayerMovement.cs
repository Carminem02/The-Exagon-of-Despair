using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    Animator anim;

    //variabili modificabili
    [SerializeField]
    float movespeed = 3f;
    [SerializeField]
    float jumpForce = 1.4f;

    bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        jumping();
    }

    void Movement()
    {
        float h =Input.GetAxis("Horizontal");
        Vector2 velocity = new Vector2(Vector2.right.x * movespeed * h, body.velocity.y);
        body.velocity = velocity;


        if (velocity.x < 0)
        {
            body.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            body.transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void jumping()
    {
        if(isJumping)
        {
            if(body.velocity.y == 0)
            {
                isJumping = false;
            }
        }
        else
        {
            if(Input.GetAxis("Jump") > 0)
            {
                body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
            }
        }
    }

}