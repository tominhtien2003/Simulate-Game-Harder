using System.Collections;
using UnityEngine;

public class TrapHide : MonoBehaviour
{
    [SerializeField] private LayerMask playerMask;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private bool isActivated;
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (FindPlayer())
        {
            if (!isActivated)
            {
                StartCoroutine(Activated());
            }
            else
            {
                
            }
        }
    }
    private IEnumerator Activated()
    {
        isActivated = true;
        yield return new WaitForSeconds(1f);
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
        yield return new WaitForSeconds(1.5f);
        spriteRenderer.enabled = true;
        boxCollider.enabled = true;
        isActivated = false;
    }
    private bool FindPlayer()
    {
        Collider2D collider2D = Physics2D.OverlapBox(transform.position, boxCollider.bounds.size + new Vector3(0f,.1f,0f), 0f, playerMask);
        return collider2D != null;
    }
}
