using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Game3Player : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    private float force;   // ������

    private bool isJump;  // ���� üũ

    [SerializeField]
    private LayerMask groundLayer;  // �ٴ� ���̾�
    public LayerMask uiLayer; // UI ���̾�

    private RaycastHit2D hit;   // �ٴ� üũ�� ����ĳ��Ʈ

    [SerializeField]
    GameManager gameManager;

    void Update()
    {
        // �ٴ� üũ
         hit = Physics2D.Raycast(transform.position, Vector2.down, 0.4f, groundLayer);

        if (hit.collider != null)
        {
            // �ٴڿ� ������� ���� ����
            isJump = false;
        }
        else
        {
            // �ٴڿ� ���� ������ ���߿� ����
            isJump = true;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) // ��ġ �Ǵ� ���콺 Ŭ�� ����
        {
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) // UI�� Ŭ������ �ʾ��� ���� ���� ����
            {
                Jump();
            }
        }
    }

    public void Jump()
    {
        if (!isJump)
        {
            rb.AddForce(Vector2.up * force, ForceMode2D.Force);
            isJump = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("DeadZone"))
        {
            gameManager.GameEnd(2);
        }
    }

   

}
