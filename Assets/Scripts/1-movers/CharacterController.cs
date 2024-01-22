using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float m_JumpForce = 50f;                          // Amount of force added when the player jumps.
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    [SerializeField] private Collider2D m_CrouchDisableCollider;				// A collider that will be disabled when crouching
    [SerializeField] float Speed;
    [SerializeField] Rigidbody2D m_Rigidbody2D;
    //privates//
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    Animator player_anim;
    float horizontal;

    private void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        player_anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        m_Grounded = false;
        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
            }
        }
    }
    public void Move(float crouch_speed, bool jump, bool move_left, bool move_right)
    {
        //walking//
        if (move_left)
        {
            // Debug.Log("Player moving left");
            Movement();
            FlipPlayer(1);
        }
        else if (move_right)
        {
            // Debug.Log("Player moving Right");
            Movement();
            FlipPlayer(-1);
        }
        else
        {
            player_anim.SetBool("Walking", false);
        }
        //jumping//
        if (jump && m_Grounded)
            PlayerJump();
        else
            player_anim.SetBool("Jumping", false);

    }
    //tells the player to jump
    void PlayerJump()
    {
        // Debug.Log("Jumping");
        player_anim.SetBool("Jumping", true);
        // Add a vertical force to the player.
        m_Grounded = false;
        m_Rigidbody2D.AddForce(new Vector2(0f, Mathf.Lerp(m_JumpForce, 0f, 0f))); //lerp is added to smooth transition movment
    }

    //tells the player to move
    void Movement()
    {
        player_anim.SetBool("Walking", true);
        m_Rigidbody2D.velocity = new Vector2(Mathf.Lerp(horizontal * Speed, 0.5f, 0), m_Rigidbody2D.velocity.y); //lerp is added to smooth transition movment
    }
    //flips the player's side (1 to left, -1 to right)
    void FlipPlayer(int side)
    {
        if (side == 1) // left side
        {
            // player.localScale = new Vector3(player.localScale.x, player.localScale.y, player.localScale.z);
            transform.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (side == -1) // right side
        {
            // player.localScale = new Vector3(-1*player.localScale.x, player.localScale.y, player.localScale.z);
            transform.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}