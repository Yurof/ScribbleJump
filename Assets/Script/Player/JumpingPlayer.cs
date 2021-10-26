using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpingPlayer : MonoBehaviour
{
    public Animator animator;
    public CameraMoving cameraMouving;
    public GameObject jetpack;
    public AudioSource springSound;
    public AudioSource jumpSound;
    public AudioSource fallingSound;
    public AudioSource blackholeSound;
    public float springMultiplicator = 2;
    public float hatMultiplicator = 5;
    public float horizontalForce = 2;
    public int jumpForce = 6;
    public float blackholeDelay = 1.5f;
    public float hatDelay = 5f;
    public float hatSpeed = 2f;
    public float jetpackDelay = 5f;
    public float jetpackSpeed = 2f;

    private Rigidbody2D rb;
    private GameObject BlackHole;
  
    private CapsuleCollider2D myCollider;
    private bool fallingBlackHole = false;
    private bool hatBool = false;
    private bool jetpackBool = false;
    private float direction = 0;
    private SpriteRenderer mySprite;
    private SpriteRenderer jetpackSprite;
    private IEnumerator coroutine;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        jetpackSprite=jetpack.GetComponent<SpriteRenderer>();
        myCollider = GetComponent<CapsuleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Monsters"))
        {
            animator.SetTrigger("knockoutTrigger");
            fallingSound.Play();
            myCollider.enabled = false;
            cameraMouving.FallingDown();
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }

        else if (other.gameObject.CompareTag("BlackHoles"))
        {
            animator.SetTrigger("blackholeTrigger");
            BlackHole = other.transform.gameObject;
            fallingBlackHole = true;
            blackholeSound.Play();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            coroutine = BLackHoleDeath(blackholeDelay);
            StartCoroutine(coroutine);
        }

        else if (other.relativeVelocity.y > 0)
        {
            if (other.gameObject.CompareTag("Plateformes"))
            {
                jumpSound.Play();
                animator.SetTrigger("jumpingTrigger");
                Jump();
            }

            else if (other.gameObject.CompareTag("spring"))
            {
                springSound.Play();
                animator.SetTrigger("jumpingTrigger");
                rb.AddForce(Vector2.up * jumpForce * springMultiplicator, ForceMode2D.Impulse);
            }
            else if (other.gameObject.CompareTag("hat"))
            {
                //animator.SetTrigger("hatTrigger");
                animator.SetBool("hatBool", true);
                //rb.AddForce(Vector2.up * jumpForce * hatMultiplicator, ForceMode2D.Impulse);
                hatBool = true;
                //myCollider.enabled = false;
                Destroy(other.gameObject);
                coroutine = Hat(hatDelay);
                StartCoroutine(coroutine);
            }
            else if (other.gameObject.CompareTag("jetpack"))
            {
                animator.SetTrigger("jetpackTrigger");
                Debug.Log("jetpack");
                animator.SetBool("jetpackBool", true);
                //rb.AddForce(Vector2.up * jumpForce * hatMultiplicator, ForceMode2D.Impulse);
                jetpackBool = true;
                //myCollider.enabled = false;
                Destroy(other.gameObject);
                coroutine = Jetpack(jetpackDelay);
                StartCoroutine(coroutine);
            }
        }
    }

    public void Jump()
    {
        Vector2 velocity = rb.velocity;
        velocity.y = jumpForce;
        rb.velocity = velocity;
    }

    public void Moving(float directionInput)
    {
        direction = directionInput;
        Debug.Log(direction);
        Debug.Log(directionInput);
        if (direction != 0) {
            if (mySprite.flipX != (direction < 0))
            {
                jetpack.gameObject.transform.position = new Vector2(jetpack.gameObject.transform.position.x + (direction * -0.67f), jetpack.gameObject.transform.position.y);
            }
            mySprite.flipX = (direction < 0);
            jetpackSprite.flipX = (direction > 0);
            
        }
    }

    private void Update()
    {
        rb.velocity = new Vector2(direction * horizontalForce, rb.velocity.y);


        if (fallingBlackHole)
        {
            //transform.RotateAround(BlackHole.transform.position, new Vector3(0, 0, 20), Time.deltaTime * 10);
            transform.position = Vector3.MoveTowards(transform.position, BlackHole.transform.position, Time.deltaTime * 20);
        }
        if (hatBool)
        {
            //Debug.Log("UP");
            //transform.Translate(Vector2.up * Time.deltaTime *10f);
            //transform.position = new Vector2(transform.position.x, transform.position.y+hatSpeed);
            //rb.AddForce(Vector2.up * jumpForce * hatMultiplicator, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, hatSpeed);
        }
        if (jetpackBool)
        {
            rb.velocity = new Vector2(rb.velocity.x, jetpackSpeed);
        }

    }


    private IEnumerator BLackHoleDeath(float _delay)
    {
        yield return new WaitForSeconds(_delay);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
    }

    private IEnumerator Hat(float _delay)
    {
        Debug.Log("start");
        yield return new WaitForSeconds(_delay);
        Debug.Log("finish");
        //animator.SetTrigger("hatTrigger");
        animator.SetBool("hatBool", false);
        //myCollider.enabled = false;
        hatBool = false;
    }
    private IEnumerator Jetpack(float _delay)
    {
        Debug.Log("start");
        yield return new WaitForSeconds(_delay);
        Debug.Log("finish");
        //animator.SetTrigger("hatTrigger");
        animator.SetBool("jetpackBool", false);
        //myCollider.enabled = false;
        jetpackBool = false;
    }

}