using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        movement.y = CrossPlatformInputManager.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * StaticDataManager.playerMoveSpeed * Time.deltaTime);
        if (CrossPlatformInputManager.GetAxisRaw("Horizontal") != 0 || CrossPlatformInputManager.GetAxisRaw("Vertical") != 0)
            animator.SetBool("ShootWalk", true);
        else
            animator.SetBool("ShootWalk", false);
    }
}