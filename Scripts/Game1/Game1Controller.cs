using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game1Controller : MonoBehaviour
{
    [SerializeField]
    private Transform go_Floor; // 바닥 오브젝트

    [SerializeField]
    private float rotationSpeed; // 회전 속도

    private float targetAngle = 0f; // 목표 회전 각도
    private bool isPressLeft = false;
    private bool isPressRight = false;

    private void Update()
    {
        // 왼쪽 버튼이 눌려 있으면 왼쪽으로 회전
        if (isPressLeft)
        {
            targetAngle = Mathf.Clamp(targetAngle + rotationSpeed * Time.deltaTime * 10f, -20f, 20f);
        }
        // 오른쪽 버튼이 눌려 있으면 오른쪽으로 회전
        if (isPressRight)
        {
            targetAngle = Mathf.Clamp(targetAngle - rotationSpeed * Time.deltaTime * 10f, -20f, 20f);
        }

        // 목표 각도로 부드럽게 회전
        float currentAngle = go_Floor.eulerAngles.z;
        if (currentAngle > 180f) currentAngle -= 360f; // -180 ~ 180 범위로 변환
        float newAngle = Mathf.LerpAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
        go_Floor.rotation = Quaternion.Euler(0, 0, newAngle);
    }

    // 왼쪽 버튼 클릭 시 호출
    public void DownRotateLeft()
    {
        isPressLeft = true;
    }

    // 왼쪽 버튼에서 클릭 그만 했을때 호출
    public void UpRotateLeft()
    {
        isPressLeft = false;
    }

    // 오른쪽 버튼 클릭 시 호출
    public void DownRotateRight()
    {
        isPressRight = true;
    }

    // 오른쪽 버튼에서 클릭 그만 했을때 호출
    public void UpRotateRight()
    {
        isPressRight = false;
    }
}
