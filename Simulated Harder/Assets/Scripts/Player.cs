using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int endLevel;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider2D;
    private bool isWallJumping;
    private bool isWallSliding;


    [SerializeField] private float moveSpeed;
    [SerializeField] private float forceJump;
    [SerializeField] private float forceFall;
    [SerializeField] private float speedFallOnWall;
    [SerializeField] private Vector2 wallJumpForce;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private LayerMask wallMask;
    [SerializeField] private Transform effectDeat;
    [SerializeField] private BoxCollider2D checkGround;
    [SerializeField] private BoxCollider2D checkWall;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void Start()
    {
        GameManager.instance.isDeathPlayer = false;
    }
    private void Update()
    {
        //Debug.Log(IsGround());
    }
    private void FixedUpdate()
    {

        if (!isWallSliding)
        {
            HandleJump();
            HandleMovement();
        }        
        WallSlide();
        HandleJumpWall();
    }
    private void HandleMovement()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        if (inputHorizontal != 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * inputHorizontal, transform.localScale.y, transform.localScale.z);
        }
        rb.velocity = new Vector2(inputHorizontal * moveSpeed, rb.velocity.y);
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && !IsGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, -forceFall);
        }
    }
    private void HandleJumpWall()
    {
        if (isWallSliding && PressKeyJump())
        {
            
            rb.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * wallJumpForce.x,rb.velocity.y +wallJumpForce.y);
        }
        else
        {
            
        }
    }
    private void WallSlide()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        if (IsWall() && !IsGround() && inputHorizontal!=0f && ! (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) )
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, -speedFallOnWall);
            
        }
        else
        {
            isWallSliding = false;
        }
    }
    private bool PressKeyJump()
    {
        return Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
    }
    private void HandleJump()
    {
        if (PressKeyJump() && IsGround())
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
    
    private IEnumerator EffectDeath()
    {
        effectDeat.gameObject.SetActive(true);
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        GameObject[] playerList = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject _player in playerList)
        {
            _player.transform.GetComponent<Player>().enabled = false;
        }
        yield return new WaitForSeconds(1f);
        effectDeat.gameObject.SetActive(false);
    }
    private bool IsGround()
    {
        RaycastHit2D hit = Physics2D.BoxCast(checkGround.bounds.center, checkGround.bounds.size, 0f, Vector2.down, 0f, groundMask);
        return hit.collider != null;
    }
    private bool IsWall()
    {
        RaycastHit2D hit = Physics2D.BoxCast(checkWall.bounds.center, checkWall.bounds.size, 0f, Vector2.right, 0f, wallMask);
        return hit.collider != null;
    }
    private bool IsCeil()
    {
        RaycastHit2D hit = Physics2D.BoxCast(checkWall.bounds.center, checkWall.bounds.size, 0f, Vector2.right, 0f, groundMask);
        return hit.collider != null;
    }
}
