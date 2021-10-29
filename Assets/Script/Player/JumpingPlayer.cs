using System.Collections;
using UnityEngine;

public class JumpingPlayer : MonoBehaviour
{
    public Animator animator;
    public CameraMoving cameraMouving;
    public GameObject jetpack;
    public AudioSource springSound;
    public AudioSource hatSound;
    public AudioSource jetpackSound;
    public AudioSource jumpSound;
    public AudioSource blackholeSound;
    public float springMultiplicator = 2;
    public float hatMultiplicator = 5;
    public float horizontalForce = 2;
    public float blackholeDelay = 1.5f;
    public float hatDelay = 5f;
    public float hatSpeed = 2f;
    public float jetpackDelay = 5f;
    public float jetpackSpeed = 2f;
    public float jumpForce = 8f;

    private Rigidbody2D rb;
    private GameObject BlackHole;
    private CapsuleCollider2D myCollider;
    private bool fallingBlackHole = false;
    private bool hatBool = false;
    private bool jetpackBool = false;
    private float direction = 0;
    private SpriteRenderer mySprite;
    private SpriteRenderer jetpackSprite;
    private bool boolOneCollision = true; //only count the first collision with an ennemie

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        jetpackSprite = jetpack.GetComponent<SpriteRenderer>();
        myCollider = GetComponent<CapsuleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Monsters") && boolOneCollision)
        {
            boolOneCollision = false;
            animator.SetTrigger("knockoutTrigger");
            myCollider.enabled = false;
            cameraMouving.FallingDown();
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            StopDoodle();
        }
        else if (other.gameObject.CompareTag("BlackHoles") && boolOneCollision)
        {
            boolOneCollision = false;
            animator.SetTrigger("blackholeTrigger");
            BlackHole = other.transform.gameObject;
            fallingBlackHole = true;
            blackholeSound.Play();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            StopDoodle();
            StartCoroutine(BLackHoleDeath(blackholeDelay));
        }
        else if (other.relativeVelocity.y > 0)
        {
            if (other.gameObject.CompareTag("Plateformes"))
            {
                animator.SetTrigger("jumpingTrigger");
                jumpSound.Play();
                Jump();
            }
            else if (other.gameObject.CompareTag("spring"))
            {
                animator.SetTrigger("jumpingTrigger");
                springSound.Play();
                rb.AddForce(Vector2.up * jumpForce * springMultiplicator, ForceMode2D.Impulse);
            }
            else if (other.gameObject.CompareTag("hat"))
            {
                animator.SetBool("hatBool", true);
                hatBool = true;
                hatSound.Play();
                Destroy(other.gameObject);
                StartCoroutine(Hat(hatDelay));
            }
            else if (other.gameObject.CompareTag("jetpack"))
            {
                animator.SetTrigger("jetpackTrigger");
                animator.SetBool("jetpackBool", true);
                jetpackBool = true;
                jetpackSound.time = 0.1f;
                jetpackSound.Play();
                Destroy(other.gameObject);
                StartCoroutine(Jetpack(jetpackDelay));
            }
        }
    }

    public void Jump()
    {
        Vector2 velocity = rb.velocity;
        velocity.y = jumpForce;
        rb.velocity = velocity;
    }

    public void Moving(float directionInput) //flip sprite of doodle and jetpack
    {
        direction = directionInput;
        if (direction != 0)
        {
            if (mySprite.flipX != (direction < 0))
            {
                jetpack.gameObject.transform.position = new Vector2(jetpack.gameObject.transform.position.x + (direction * -0.67f), jetpack.gameObject.transform.position.y);
            }
            mySprite.flipX = (direction < 0);
            jetpackSprite.flipX = (direction > 0);
        }
    }

    private void StopDoodle() //stop Doodle when encounter ennemies
    {
        rb.velocity = Vector2.zero;
        jetpackBool = false;
        hatBool = false;
        jetpackSound.Stop();
        hatSound.Stop();
        animator.SetBool("hatBool", false);
        animator.SetBool("jetpackBool", false);

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        rb.velocity = new Vector2(direction * horizontalForce, rb.velocity.y); //left-right movement

        if (fallingBlackHole)
        {
            transform.position = Vector3.MoveTowards(transform.position, BlackHole.transform.position, Time.deltaTime * 20); //attract to the middle of the blackhole
        }
        if (hatBool)
        {
            rb.velocity = new Vector2(rb.velocity.x, hatSpeed); //hat move up
        }
        if (jetpackBool)
        {
            rb.velocity = new Vector2(rb.velocity.x, jetpackSpeed); //jetpack move up
        }
    }

    private IEnumerator BLackHoleDeath(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        cameraMouving.FallingDown(true);
        fallingBlackHole = false;
    }

    private IEnumerator Hat(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        animator.SetBool("hatBool", false);
        hatBool = false;
        hatSound.Stop();
    }

    private IEnumerator Jetpack(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        animator.SetBool("jetpackBool", false);
        jetpackBool = false;
        jetpackSound.Stop();
    }
}