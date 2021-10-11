using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody2D rb;
    public int damage = 1;
    void Start(){
        rb.velocity = transform.up * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monsters")) { 
        Debug.Log(collision.name);

        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
    }
    void OnBecameInvisible()
    {
        enabled = false;
        Destroy(gameObject);
    }

}
