using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public Transform firePoint;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        LookDirection();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }


    // Sets Direction parameter and rotates FirePoint accordingly
    void LookDirection()
    {
        if(movement.y == 1)
        {
            animator.SetFloat("Direction", 1);
            firePoint.rotation = Quaternion.Euler(0,0,0);
        }
        else if(movement.x == 1)
        {
            animator.SetFloat("Direction", 2);
            firePoint.rotation = Quaternion.Euler(0,0,-90f);
        }
        else if(movement.x == -1)
        {
            animator.SetFloat("Direction", -2);
            firePoint.rotation = Quaternion.Euler(0,0,90f);
        }
        else if(movement.y == -1)
        {
            animator.SetFloat("Direction", -1);
            firePoint.rotation = Quaternion.Euler(0,0,180f);
        }
    }
}
