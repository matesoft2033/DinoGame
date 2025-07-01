using UnityEngine;

public class Dino : MonoBehaviour
{
    [SerializeField] private float velocity = 0.5f;
    [SerializeField] private AudioSource jumpAudio;

    private bool isGround = false;
    private float defY = 0;

    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D boxCollider;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        defY = boxCollider.size.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") isGround = false;
    }
    private void Jump()
    {
        if (!isGround) return;
        jumpAudio.Play();
        rb.linearVelocity = Vector2.up * velocity;

    }

    private void DownEvent(bool move)
    {
        anim.SetBool("isDown", move);

        if (move)
        {
            boxCollider.size = new Vector2(boxCollider.size.x, defY - 0.2f);
            boxCollider.offset = new Vector2(boxCollider.offset.x, boxCollider.offset.y - 0.1f);
            rb.linearVelocity = Vector2.down * (velocity / 2);
        }
        else
        {
            boxCollider.size = new Vector2(boxCollider.size.x, defY);
            boxCollider.offset = new Vector2(boxCollider.offset.x, boxCollider.offset.y + 0.1f);
        }
    }


    private void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
            return;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            DownEvent(false);
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            DownEvent(true);
        }
    }


}