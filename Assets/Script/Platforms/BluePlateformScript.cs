using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlateformScript : MonoBehaviour
{
    private bool booright=true;
    public float bluespeed=2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 2.2f)
        {
            booright = false;
        }
        if (transform.position.x <= -2.2f)
        {
            booright = true;
        }

        if (booright) {
            transform.Translate((Vector2.right)*Time.deltaTime* bluespeed);
        }
        if (!booright)
        {
            transform.Translate((Vector2.left) * Time.deltaTime* bluespeed);
        }
    }
}
