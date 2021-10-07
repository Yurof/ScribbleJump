using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public float speed = 10;
    public GameObject player;
    private float posstart;
    
    // Start is called before the first frame update
    void Start()
    {
        posstart = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    { if (player.transform.position.y > 10 + posstart)
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
    }
}
