using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    //private int numberJump;
    private TrailRenderer trailRenderer;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float forceJump;
    [SerializeField] private float forceFall;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform effectDeat;
    //[SerializeField] private int maxNumberJump;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        trailRenderer = GetComponent<TrailRenderer>();
    }
    private void Start()
    {
        GameManager.instance.isDeathPlayer = false;
    }
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        HandleMovement();
        HandleJump();
    }
    private void HandleMovement()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputHorizontal * moveSpeed, rb.velocity.y);
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && !IsGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, -forceFall);
        }
    }
    private void HandleJump()
    {
        /*if (IsGround()) numberJump = 0;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGround())
            {
                rb.velocity = new Vector2(rb.velocity.x, forceJump);
                numberJump = 1;
            }
            else if (numberJump == 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, forceJump);
                numberJump = 0;
            }
        }*/
        if (IsGround() && Input.GetKey(KeyCode.Space))
        {
            GameManager.instance.audioManager.PlaySFX("Jump");
            rb.velocity = new Vector2(rb.velocity.x, forceJump);
        }
    }
    public void Death()
    {
        GameManager.instance.isDeathPlayer = true;
        StartCoroutine(EffectDeath());
    }
    private bool IsGround()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, groundMask);
        return hit.collider != null;
    }
    private IEnumerator EffectDeath()
    {
        effectDeat.gameObject.SetActive(true);
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        moveSpeed = 0f;
        forceJump = 0f;
        yield return new WaitForSeconds(1f);
        effectDeat.gameObject.SetActive(false);
    }
}
