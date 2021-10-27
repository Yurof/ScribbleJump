using UnityEngine;

public class JumpOnHead : MonoBehaviour
{
    public AudioSource jumpingSound;
    public float jumpForce = 6f;
    public float fallingDeathSpeed = 5f;

    private GameObject Enemy;
    private Rigidbody2D rb;
    private bool deathBool = false;

    private void Start()
    {
        Enemy = gameObject.transform.parent.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpingSound.Play();
        rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        deathBool = true;
        Enemy.GetComponent<Collider2D>().enabled = false;
        //Destroy(Enemy);
    }

    private void Update()
    {
        if (deathBool)
        {
            Enemy.transform.Translate(Vector2.down * Time.deltaTime * fallingDeathSpeed);
        }
    }
}