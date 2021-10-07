using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RepeatBackground : MonoBehaviour
{
    private Vector2 startpos;
    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position;
        setCountText();

    }
    void setCountText()
    {
        float scorevalue = (transform.position.y)-startpos.y;
        score.text = "score: " + scorevalue.ToString();


    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < startpos.y - 50)
        {
            transform.position = startpos;
        }
    }
}
