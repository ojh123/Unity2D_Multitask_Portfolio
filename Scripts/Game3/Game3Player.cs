using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Game3Player : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    private float force;   // 점프힘

    private bool isJump;  // 점프 체크

    [SerializeField]
    private LayerMask groundLayer;  // 바닥 레이어
    public LayerMask uiLayer; // UI 레이어

    private RaycastHit2D hit;   // 바닥 체크용 레이캐스트

    [SerializeField]
    GameManager gameManager;

    void Update()
    {
        // 바닥 체크
         hit = Physics2D.Raycast(transform.position, Vector2.down, 0.4f, groundLayer);

        if (hit.collider != null)
        {
            // 바닥에 닿았으면 점프 가능
            isJump = false;
        }
        else
        {
            // 바닥에 닿지 않으면 공중에 있음
            isJump = true;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) // 터치 또는 마우스 클릭 감지
        {
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)) // UI가 클릭되지 않았을 때만 점프 실행
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
