using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using MLAPI;

public class Player1 : MonoBehaviour
{
    [SerializeField, Range(0.1f, 100f)]
    float jumpForce;

    Animator anim;
    SpriteRenderer spr;
    
    Rigidbody2D rb2D;
    PlayerControls playerControls;

    [SerializeField]
    Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 15f)]
    float rayDistance = 5f;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    LayerMask platformLayer;
    
    void Awake() 
    {
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        playerControls = new PlayerControls();
    }
        
    void OnEnable()
    {
        playerControls.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();
    }

    void Start()
    {
        
            playerControls.Gameplay.Jump.performed += ctx => Jump();
        

    }

    void FixedUpdate()
    {
        anim.SetFloat("velocityY", Mathf.Abs(rb2D.velocity.y));
        anim.SetBool("ground", IsGrounding);
        anim.SetBool("platform", IsGroundingPlatform);
    }
        
    void Jump()
    {
        
            if (IsGrounding)
            {
                anim.SetTrigger("JumpON");
                rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

            if (IsGroundingPlatform && rb2D.velocity.y == 0)
            {
                anim.SetTrigger("JumpON");
                rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        
    }

    bool IsGrounding => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
    bool IsGroundingPlatform => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, platformLayer);
    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
}
