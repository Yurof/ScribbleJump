using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animator;
    public AudioSource shootingsound;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up") || Input.GetMouseButtonDown(0))
        {
            shootingsound.Play();
            animator.SetBool("shooting",true);
            animator.SetTrigger("shootingt");
            Shoot();
            
        }
        
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //animator.SetBool("shooting", false);
    }
}
