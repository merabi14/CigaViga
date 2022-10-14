using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Movment Configuration")]
    [SerializeField] float torqueAmount = 10f;
    [SerializeField] float speedForce= 5f;
    [SerializeField] float jumpForce = 10f;
    [Space]
    [Header("Mask for ground Check")]
    [SerializeField] LayerMask layermask;
    
    float playerMov;
    Rigidbody2D rb;
    CapsuleCollider2D capsuleCollider2d;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider2d = GetComponent<CapsuleCollider2D>();
    }
    private void Update()
    {
        playerMov = Input.GetAxisRaw("Horizontal");
        PlayerJump();
    }

    private void FixedUpdate()
    {
        PlayerMomvment();
    }

    void PlayerMomvment()
    {
        //Flip
        if (playerMov != 0)
        {
            rb.AddTorque(-playerMov * torqueAmount);
        }
        //Acceleration
        if (transform.rotation.z < -0.08)
        {
            rb.AddForce(transform.right * speedForce, ForceMode2D.Force);
        }
    }
    
    void PlayerJump()
    {
        //Jumping
        if (IsGrounded() && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("Jump Suka");
        }
    }
    bool IsGrounded()
    {
        RaycastHit2D _rayCastHit = Physics2D.Raycast(capsuleCollider2d.bounds.center, Vector2.down, capsuleCollider2d.bounds.extents.y + .2f, layermask);
        
        //For visual
        Color _rayColor;
        if (_rayCastHit.collider != null)
        {
            _rayColor = Color.green;
        }else
        {
            _rayColor = Color.red;
        }
        Debug.DrawRay(capsuleCollider2d.bounds.center, Vector2.down * (capsuleCollider2d.bounds.extents.y + .2f),_rayColor);
        //
        return _rayCastHit.collider != null;
    }

}
