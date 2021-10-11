using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            animator.SetBool("shooting",true);
            Shoot();
            //animator.SetBool("shooting", false);
        }
        
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
