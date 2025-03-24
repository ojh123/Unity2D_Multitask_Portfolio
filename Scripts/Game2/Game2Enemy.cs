using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2Enemy : MonoBehaviour
{
    public float direction; // 날아갈 방향
    [SerializeField]
    private float force; // 날아가는 힘

    private Vector3 movement;


    private void Update()
    {
        Vector3 movement = new Vector3(direction * force * Time.deltaTime, 0, 0); // x축으로 이동
        transform.Translate(movement); // 이동 적용
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemySpawner"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
