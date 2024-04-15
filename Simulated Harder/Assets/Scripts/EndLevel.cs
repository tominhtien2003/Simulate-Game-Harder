using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Player.endLevel++;
            if (Player.endLevel == GameObject.FindGameObjectsWithTag("Player").Length)
            {
                GameManager.instance.LoadLevel();
            }
        }
    }
}
