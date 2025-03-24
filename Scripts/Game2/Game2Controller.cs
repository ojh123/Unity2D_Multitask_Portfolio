using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game2Controller : MonoBehaviour
{
    [SerializeField]
    private Transform[] columns;
    [SerializeField]
    private Transform player;

    private int startIndex;

    private void Start()
    {
        startIndex = 2;
    }

    public void UpBtn()
    {
        if (startIndex > 0) // 0���� Ŭ���� ����
        {
            startIndex--;
            player.position = columns[startIndex].position;
        }
    }

    public void DownBtn()
    {
        if (startIndex < columns.Length - 1)  // columns�� ���̸� �Ѿ�� �ʵ���
        {
            startIndex++;
            player.position = columns[startIndex].position;
        }
    }
}
