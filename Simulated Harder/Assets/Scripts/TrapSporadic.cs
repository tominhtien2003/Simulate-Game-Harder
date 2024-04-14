using System.Collections;
using UnityEngine;
//Sporadic : Lúc ẩn lúc hiện
public class TrapSporadic : MonoBehaviour
{
    private bool isShow;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider2D;
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }
    private void Update()
    {
        if (!isShow)
        {
            Sporadic();
        }
    }
    private void Sporadic()
    {
        StartCoroutine(IESporadic());
    }
    private IEnumerator IESporadic()
    {
        isShow = true;
        yield return new WaitForSeconds(1f);
        spriteRenderer.enabled = false;
        polygonCollider2D.enabled = false;
        yield return new WaitForSeconds(1f);
        isShow = false;
        spriteRenderer.enabled = true;
        polygonCollider2D.enabled = true;
    }
}
