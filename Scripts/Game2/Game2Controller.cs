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
        if (startIndex > 0) // 0보다 클때만 감소
        {
            startIndex--;
            player.position = columns[startIndex].position;
        }
    }

    public void DownBtn()
    {
        if (startIndex < columns.Length - 1)  // columns의 길이를 넘어가지 않도록
        {
            startIndex++;
            player.position = columns[startIndex].position;
        }
    }
}
