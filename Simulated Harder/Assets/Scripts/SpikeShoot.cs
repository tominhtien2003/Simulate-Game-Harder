using UnityEngine;

public class SpikeShoot : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;

    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        rb.isKinematic = true;
    }
    private void Update()
    {
        if (FindPlayer())
        {
            rb.isKinematic = false;
        }
    }
    private bool FindPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 5f, playerMask);
        return hit.collider != null;
    }
}
