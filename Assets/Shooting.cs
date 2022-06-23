using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;
    public Animator animator;
    public float arrowForce = 2f;

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Attack", Input.GetButtonDown("Fire1"));

        if(Input.GetButtonDown("Fire1") && animator.GetFloat("Speed") == 0)
        {
            Invoke("Shoot", 0.4f);
        }
    }

    // Creates instances of prefab and adds a force
    void Shoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
        
    }

}
