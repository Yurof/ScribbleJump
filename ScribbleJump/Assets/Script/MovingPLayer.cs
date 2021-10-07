using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovingPLayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public int jumpforce = 5;
    public float horizontalforce = 3;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow) )
        {
            rb.velocity = new Vector2(-horizontalforce, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(horizontalforce, rb.velocity.y);
        }
    }
}
