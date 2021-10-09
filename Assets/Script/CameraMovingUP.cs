using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovingUP : MonoBehaviour
{
    public float ecart =0.1f;
    public GameObject player;
    private float posstart;

    // Start is called before the first frame update
    void Start()
    {
        posstart = player.transform.position.y;
    }


    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y > ecart + posstart)
        {
            transform.Translate(Vector2.up * (player.transform.position.y - (ecart + posstart)));
            posstart = player.transform.position.y;
        }
    }
}
