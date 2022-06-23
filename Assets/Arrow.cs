using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject HitEffect;

    void OnCollisionEnter2D(Collision2D col)
    {
        GameObject effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.3f);
        Destroy(gameObject);
    }
}
