using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player22 : MonoBehaviour
{
    [SerializeField, Range(0.1f, 100f)]
    float jumpForce;

    Animator anim;
    SpriteRenderer spr;
    
    Rigidbody2D rb2D;
    Player2 player2;

    [SerializeField]
    Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 15f)]
    float rayDistance = 5f;
    [SerializeField]
    LayerMask groundLayer;
    [SerializeField]
    LayerMask platformLayer;

    
    public GameObject p2;
    public GameObject bg;
    public GameObject p1;

    public CameraMovement cameraMovementP1;
    public CameraMovement cameraMovementP2;
    public CameraMovement cameraMovementBg;

    private GameObject gei;

    public GameObject cajaOn;
    public GameObject barrilOn;
    public GameObject cuervoOn;
    public GameObject cajaOn2;


    void Awake() 
    {
        
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        player2 = new Player2();

        p1 = GameObject.Find("Player(Clone)");
        cameraMovementP1 = p1.GetComponent<CameraMovement>();

        bg = GameObject.Find("Game Manager");
        cameraMovementBg = bg.GetComponent<CameraMovement>();

        cameraMovementP2 = p2.GetComponent<CameraMovement>();

        cajaOn = GameObject.Find("SpawnPointCaja");
        cajaOn2 = GameObject.Find("SpawnPointCaja2");
        barrilOn = GameObject.Find("SpawnPointBarril");
        cuervoOn = GameObject.Find("SpawnPointCuervo");
    }
     
    void OnEnable()
    {
        player2.Enable();
    }

    void OnDisable()
    {
        player2.Disable();
    }

    void Start()
    {
        gei = GameObject.FindGameObjectWithTag("gei");

        player2.Movement.Jump2.performed += ctx => Jump();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "gei")
        {
            cajaOn.GetComponent<Spawner>().enabled = true;
            cajaOn2.GetComponent<Spawner>().enabled = true;
            barrilOn.GetComponent<Spawner>().enabled = true;
            cuervoOn.GetComponent<Spawner>().enabled = true;
            cameraMovementP1.cameraSpeed = 10f;
            cameraMovementP2.cameraSpeed = 10f;
            cameraMovementBg.cameraSpeed = 10f;
            Destroy(gei.gameObject);
        }
    }

    void FixedUpdate()
    {
        anim.SetFloat("velocityY", Mathf.Abs(rb2D.velocity.y));
        anim.SetBool("ground", IsGrounding);
        anim.SetBool("platform", IsGroundingPlatform);
    }
        
    void Jump()
    {   
        if(IsGrounding)
        {     
            anim.SetTrigger("JumpON");
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if(IsGroundingPlatform && rb2D.velocity.y == 0)
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
