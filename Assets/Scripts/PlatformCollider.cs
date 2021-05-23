using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollider : MonoBehaviour
{
    PlayerControls playerControls;

    [SerializeField]
    Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 15f)]
    float rayDistance = 5f;
    [SerializeField]
    LayerMask platformLayer;
    Animator anim;

    Collider2D col;

    void Awake() 
    {
        playerControls = new PlayerControls();
        col = GetComponent<Collider2D>();
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
        playerControls.Gameplay.Fall.performed += ctx => Fall();
    }
    
    void Fall()
    {
        StartCoroutine(PlayerFall());
    }

    IEnumerator PlayerFall()
    {
        if(IsGroundingPlatform)
        {
            col.enabled = false;
            yield return new WaitForSeconds(.22f);
            col.enabled = true;
        }
    }

    bool IsGroundingPlatform => Physics2D.Raycast(transform.position, Vector2.down, rayDistance, platformLayer);
    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }
}
