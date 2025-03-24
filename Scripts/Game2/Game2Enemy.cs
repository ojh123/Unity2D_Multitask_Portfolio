using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2Enemy : MonoBehaviour
{
    public float direction; // ���ư� ����
    [SerializeField]
    private float force; // ���ư��� ��

    private Vector3 movement;


    private void Update()
    {
        Vector3 movement = new Vector3(direction * force * Time.deltaTime, 0, 0); // x������ �̵�
        transform.Translate(movement); // �̵� ����
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemySpawner"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
