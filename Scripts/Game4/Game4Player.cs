using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4Player : MonoBehaviour
{
    [SerializeField]
    private bl_Joystick js; // 조이스틱
    
    [SerializeField]
    private float speed; // 움직일 속도

    void Update()
    {
        // 스틱이 향해있는 방향을 저장해준다.
        Vector3 dir = new Vector3(js.Horizontal, js.Vertical, 0);

        // 정규화
        dir.Normalize();

        // 오브젝트의 위치를 dir 방향으로 이동시킨다.
        transform.position += dir * speed * Time.deltaTime;
    }
  
}
