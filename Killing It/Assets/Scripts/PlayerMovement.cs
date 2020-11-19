using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    public Animator animator;

    Vector2 movement;

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
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        if(CrossPlatformInputManager.GetAxisRaw("Horizontal") != 0 || CrossPlatformInputManager.GetAxisRaw("Vertical") != 0)
        {
            animator.SetBool("ShootWalk", true);
        }
        else
        {
            animator.SetBool("ShootWalk", false);
        }
    }
}
