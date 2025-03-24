using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4Player : MonoBehaviour
{
    [SerializeField]
    private bl_Joystick js; // ���̽�ƽ
    
    [SerializeField]
    private float speed; // ������ �ӵ�

    void Update()
    {
        // ��ƽ�� �����ִ� ������ �������ش�.
        Vector3 dir = new Vector3(js.Horizontal, js.Vertical, 0);

        // ����ȭ
        dir.Normalize();

        // ������Ʈ�� ��ġ�� dir �������� �̵���Ų��.
        transform.position += dir * speed * Time.deltaTime;
    }
  
}
