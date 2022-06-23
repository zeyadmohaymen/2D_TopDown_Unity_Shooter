using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyExplosion;

    [SerializeField] float health, maxhealth = 3f;
    // Start is called before the first frame update
    private void Start()
    {
        health = maxhealth;
    }

    public void TakeDamage(float Damage)
    {
        health -= Damage;

        if(health <= 0)
        {
            GameObject effect = Instantiate(EnemyExplosion, transform.position, Quaternion.identity);
            Destroy(effect, 0.4f);
            Destroy(gameObject);
        }
    }

}
