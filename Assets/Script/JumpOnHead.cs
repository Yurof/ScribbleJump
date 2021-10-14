using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnHead : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Enemy;
    private Rigidbody2D rigid;
    public AudioSource jumpingsound;
    void Start()
    {
        Enemy = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        jumpingsound.Play();
        rigid = collision.gameObject.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * 6, ForceMode2D.Impulse);
        Destroy(Enemy);
    }
}
