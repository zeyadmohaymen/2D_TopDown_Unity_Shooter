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
            resetPos();
            animator.SetFloat("Direction", 1);
            firePoint.RotateAround(rb.position, new Vector3(0,0,1), 0);
        }
        else if(movement.x == 1)
        {
            resetPos();
            animator.SetFloat("Direction", 2);
            firePoint.RotateAround(rb.position, new Vector3(0,0,1), -90f);
        }
        else if(movement.x == -1)
        {
            resetPos();
            animator.SetFloat("Direction", -2);
            firePoint.RotateAround(rb.position, new Vector3(0,0,1), 90f);
        }
        else if(movement.y == -1)
        {
            resetPos();
            animator.SetFloat("Direction", -1);
            firePoint.RotateAround(rb.position, new Vector3(0,0,1), 180f);
        }
        
    }

    // Resets local position of firepoint
    void resetPos()
    {
        firePoint.rotation = Quaternion.Euler(0,0,0);
        firePoint.localPosition = new Vector3(0,0.258f,0);
    }
}
