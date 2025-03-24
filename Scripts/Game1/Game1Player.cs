using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Player : MonoBehaviour
{
    [SerializeField]
    private GameManager gameManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("DeadZone"))
        {
            gameManager.GameEnd(0);
        }
    }
}
