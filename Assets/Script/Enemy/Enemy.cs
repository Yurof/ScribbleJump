using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int health = 1;
    public Animator animator;

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("TakeDamage");
        health -= damage;
        if (health <= 0)
        {            
            Destroy(gameObject);
        }
    }
}