using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animator;
    public AudioSource shootingsound;

    public void Shoot()
    {
        animator.SetBool("shooting", true);
        animator.SetTrigger("shootingt");
        shootingsound.Play();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
