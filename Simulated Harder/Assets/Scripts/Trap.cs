using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trap : MonoBehaviour
{
    //public event EventHandler OnDeathPlayer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !GameManager.instance.isDeathPlayer)
        {
            collision.GetComponent<Player>().Death();
            GameManager.instance.ResetLevel();
        }
    }
}
